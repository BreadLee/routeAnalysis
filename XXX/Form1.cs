using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MapWinGIS;

namespace XXX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection connection_;
        #region 图幅操作
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
        }

        private void 全幅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMap1.ZoomToMaxExtents();
        }

        private void 漫游ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openshp = new OpenFileDialog();
            MapWinGIS.Shapefile shpfile1 = new MapWinGIS.Shapefile();
            openshp.Filter = "shp文件|*.shp";
            openshp.RestoreDirectory = true;
            int intHandler1;
            if (openshp.ShowDialog() == DialogResult.OK)
            {
                shpfile1.Open(openshp.FileName, null);
                intHandler1 = axMap1.AddLayer(shpfile1, true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionStr = "server=127.0.0.1;user id=root;password=newpassword;database=gzuguide";
            connection_ = new MySqlConnection(connectionStr);
            connection_.Open();

            string StopSql = "select BSName from busstops where Note =" + 1;
            MySqlDataAdapter stopad = new MySqlDataAdapter(StopSql, connection_);
            DataTable stopTable = new DataTable();
            stopad.Fill(stopTable);
            string addName;
            for (int i = 0; i < stopTable.Rows.Count; i++)
            {
                addName = stopTable.Rows[i][0].ToString();
                comboBox1.Items.Add(addName);
                comboBox2.Items.Add(addName);
            }

            MapWinGIS.Shapefile shpfile1 = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile shpfile2=new MapWinGIS.Shapefile();
            int intHandler1;
            int intHandler2;
            string filename = "G:\\#导航设计\\广州大学城矢量地图\\广州大学城全要素地图\\广州大学城全要素地图\\道路\\boundary.shp";
            string filename2="G:\\#导航设计\\广州大学城矢量地图\\广州大学城全要素地图\\广州大学城全要素地图\\dxc_vector\\dxc_vector\\road";
            shpfile1.Open(filename, null);
            shpfile2.Open(filename2, null);
            intHandler1 = axMap1.AddLayer(shpfile1, true);
            intHandler2 = axMap1.AddLayer(shpfile2, true);
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;
        }
        #endregion

        #region 公交导航
        private void lineShow_Click(object sender, EventArgs e)
        {
            BusCommandText.Clear();
            int linehandle = axMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            string LineSearch;
            LineSearch = LineName.Text;
            #region 文字信息
            string sqlLine = "select BSName,BLNote from buslines where BLName  = '" + LineSearch + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlLine, connection_);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            //dataGridView1.DataSource = dataTable;
            //查询到表
            int rowNum = dataTable.Rows.Count;
            for (int i = 0; i <= rowNum - 1; i++)
            {
                if (i == 0)
                { BusCommandText.Text = "正方向："; }
                BusCommandText.Text = BusCommandText.Text + dataTable.Rows[i][0].ToString() + "-";
                if (i != rowNum - 1)
                {
                    int nextrow = 0;
                    int thisrow = 0;
                    nextrow = Int16.Parse(dataTable.Rows[i + 1][1].ToString());
                    thisrow = Int16.Parse(dataTable.Rows[i][1].ToString());
                    if (thisrow != nextrow)
                    { BusCommandText.Text = BusCommandText.Text + "\n" + "逆方向："; }
                }

            }
            #endregion
            #region 地图信息
            //获取数据库内容
            string sqlLineShow = "select N,E,Note,Num from buslinesshow where BLName  = '" + LineSearch + "'";
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(sqlLineShow, connection_);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);

            double[] N;
            double[] E;
            N = new double[300];
            E = new double[300];
            int rowNum2 = 0;
            rowNum2 = dataTable2.Rows.Count;
            for (int i = 0; i <= rowNum2 - 1; i++)
            {
                N[i] = double.Parse(dataTable2.Rows[i][0].ToString());
                E[i] = double.Parse(dataTable2.Rows[i][1].ToString());
            }

            //画点

            int jungleStop = 0;
            for (int i = 0; i < rowNum2 - 1; i++)
            {
                jungleStop = Int16.Parse(dataTable2.Rows[i][3].ToString());//判断是否为站点
                if (jungleStop == 1)
                {
                    axMap1.DrawPointEx(linehandle, E[i], N[i], 10, 1);
                }
            }
            //画线
            for (int n = 0; n <= rowNum2 - 1; n++)
            {
                int nextrow2 = 0;
                int thisrow2 = 0;
                nextrow2 = Int16.Parse(dataTable2.Rows[n + 1][2].ToString());
                thisrow2 = Int16.Parse(dataTable2.Rows[n][2].ToString());
                if (nextrow2 != thisrow2)
                {
                    for (int i = 0; i < n; i++)
                    {
                        axMap1.DrawLineEx(linehandle, E[i], N[i], E[i + 1], N[i + 1], 3, 1);
                    }
                    for (int i = n; i < rowNum2 - 1; i++)
                    {
                        axMap1.DrawLineEx(linehandle, E[i], N[i], E[i + 1], N[i + 1], 3, 200);
                    }
                    break;
                }
            }




            #endregion

        }

        private void Search_Click(object sender, EventArgs e)
        {
            BusCommandText.Clear();
            BusAllText.Clear();
            string startP = comboBox1.Text;
            string endP = comboBox2.Text;
            int StartbuslineCount = 0;
            //结果参数（线路/方向/站数）
            string[] Rbusline = new string[80];
            int[] Rdirection = new int[80];
            int[] Rstopsnum = new int[80];
            int R = 0;
            string[] result = new string[80];
            int MinR = 0;
            //显示路线用参数
            int[] BNStart = new int[80];
            int[] BNChange1 = new int[80];
            int[] BNChange2 = new int[80];
            int[] BNEnd = new int[80];
            double[] N = new double[300];
            double[] E = new double[300];
            int linehandle = axMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            int linehandle2 = axMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);



            string SearchER = "select * from buslines where BSName like '%" + endP + "%'";
            MySqlDataAdapter endsql = new MySqlDataAdapter(SearchER, connection_);
            DataTable EndP = new DataTable();
            endsql.Fill(EndP);

            string SearchER3 = "select * from buslines where BSName like '%" + startP + "%'";
            MySqlDataAdapter startsql2 = new MySqlDataAdapter(SearchER3, connection_);
            DataTable startp2 = new DataTable();
            startsql2.Fill(startp2);
            //获取终点的站点名和经过的路线
            string endPName = EndP.Rows[0][2].ToString();
            string StartPName = startp2.Rows[0][2].ToString();
            BusCommandText.Text = "\n" + "起点：" + StartPName + "\n" + "终点：" + endPName + "\n";
            BusAllText.Text = "\n" + "起点：" + StartPName + "\n" + "终点：" + endPName + "\n";


            #region 直达不需要换乘的情况下

            for (int i = 1; i < 3; i++)
            {
                //查询经过起点的路线
                string SearchSR = "select BLName,BNum,BSName from buslines where BSName like '%" + startP + "%'and BLNote=" + i;
                MySqlDataAdapter startsql = new MySqlDataAdapter(SearchSR, connection_);
                DataTable StartPLine = new DataTable();
                startsql.Fill(StartPLine);
                StartbuslineCount = StartPLine.Rows.Count;
                string StartSN = StartPLine.Rows[0][2].ToString();

                //循环各查询路线的站
                for (int a = 0; a < StartbuslineCount; a++)
                {
                    string thisLine = StartPLine.Rows[a][0].ToString();
                    int thisStopIndex = Int32.Parse(StartPLine.Rows[a][1].ToString());
                    string LineStopSQL = "select BLName,BSName,BNum from buslines where BLName ='" + thisLine + "' and BLNote=" + i;
                    MySqlDataAdapter LineStopSqad = new MySqlDataAdapter(LineStopSQL, connection_);
                    DataTable LineStopsTable = new DataTable();
                    LineStopSqad.Fill(LineStopsTable);
                    int thisDirCount = LineStopsTable.Rows.Count;

                    //这个方向下从起始站开始查找
                    for (int b = thisStopIndex; b < thisDirCount; b++)
                    {
                        string LineStopName = LineStopsTable.Rows[b][1].ToString();
                        //若可以直达不需要换乘
                        if (LineStopName == endPName)
                        {
                            int thisSNum = int.Parse(LineStopsTable.Rows[thisStopIndex][2].ToString());
                            int thisENum = int.Parse(LineStopsTable.Rows[b][2].ToString());
                            Rbusline[R] = thisLine;
                            Rdirection[R] = i;
                            Rstopsnum[R] = b - thisStopIndex + 1;
                            BNStart[R] = thisSNum;
                            BNEnd[R] = thisENum;
                            result[R] = "在【" + StartSN + "】乘坐【" + Rbusline[R] + "】路公交<" + Rstopsnum[R] + ">站直达【" + endPName + "】方向" + Rdirection[R];
                            BusAllText.Text = BusAllText.Text + result[R] + "\n";
                            R++;
                        }
                    }
                    LineStopsTable.Clear();
                }
                StartPLine.Clear();
            }
            //判断站数最少
            for (int n = 1; n < R; n++)
            {
                if (Rstopsnum[n] < Rstopsnum[MinR])
                    MinR = n;
            }
            BusCommandText.Text = BusCommandText.Text + result[MinR] + "\n";


            //*******************************************显示推荐路线**********************************************
            if (R != 0)
            {
                int startUse = BNStart[MinR];
                if (BNStart[MinR] != 1)
                {
                    startUse = BNStart[MinR] - 1;
                }
                string ShowDirSR = "select ID,N,E,Num,Note,BNum from buslinesshow where (BLName='" + Rbusline[MinR] + "') and (Note=" + Rdirection[MinR] + ") and (BNum in(" + startUse;
                //如果只有一站
                if (Rstopsnum[MinR] == 1)
                {
                    ShowDirSR = ShowDirSR + "))";
                }
                //多个站
                if (Rstopsnum[MinR] > 1)
                {
                    for (int q = startUse + 1; q < BNEnd[MinR]; q++)
                    {
                        ShowDirSR = ShowDirSR + "," + q;
                    }
                    ShowDirSR = ShowDirSR + "))";
                }
                MySqlDataAdapter show1 = new MySqlDataAdapter(ShowDirSR, connection_);
                DataTable showTable1 = new DataTable();
                show1.Fill(showTable1);
                int showCount = showTable1.Rows.Count;
                for (int p = 0; p < showCount; p++)
                {
                    N[p] = double.Parse(showTable1.Rows[p][1].ToString());
                    E[p] = double.Parse(showTable1.Rows[p][2].ToString());
                }
                //画点
                int jungleStop = 0;
                for (int k = 0; k < showCount; k++)
                {
                    jungleStop = int.Parse(showTable1.Rows[k][3].ToString());
                    if (jungleStop == 1)
                    {
                        axMap1.DrawPointEx(linehandle, E[k], N[k], 10, 1);
                    }
                }
                axMap1.DrawPointEx(linehandle, E[showCount - 1], N[showCount - 1], 8, 1);
                //画线
                for (int n = 0; n < showCount - 1; n++)
                {
                    axMap1.DrawLineEx(linehandle, E[n], N[n], E[n + 1], N[n + 1], 2, 1);
                }
            }




            #endregion

            #region 需要换乘的情况下
            if (R == 0)
            {
                //存放换乘的各种信息参数
                string[] ChangeStopN = new string[80];
                string[] FirstLine = new string[80];
                string[] SecondLine = new string[80];
                int[] FirstDir = new int[80];
                int[] SecondDir = new int[80];
                int[] FirstNum = new int[80];
                int[] SecondNum = new int[80];
                int[] SumStops = new int[80];
                double[] N2 = new double[300];
                double[] E2 = new double[300];

                for (int i = 1; i < 3; i++)
                {
                    //查询经过起点的路线
                    string SearchSR = "select BLName,BNum,BSName from buslines where BSName like '%" + startP + "%'and BLNote=" + i;
                    MySqlDataAdapter startsql = new MySqlDataAdapter(SearchSR, connection_);
                    DataTable StartPLineTable = new DataTable();
                    startsql.Fill(StartPLineTable);
                    string StartPN = StartPLineTable.Rows[0][2].ToString();
                    StartbuslineCount = StartPLineTable.Rows.Count;

                    for (int a = 0; a < StartbuslineCount; a++)
                    {
                        //该方向下该线路会经过的站
                        string thisLine = StartPLineTable.Rows[a][0].ToString();
                        int thisStopIndex = Int32.Parse(StartPLineTable.Rows[a][1].ToString());
                        string LineStopSQL = "select BLName,BSName,BNum from buslines where BLName ='" + thisLine + "' and BLNote=" + i;
                        MySqlDataAdapter LineStopSqad = new MySqlDataAdapter(LineStopSQL, connection_);
                        DataTable LineStopsTable = new DataTable();
                        LineStopSqad.Fill(LineStopsTable);
                        int thisDirCount = LineStopsTable.Rows.Count;

                        for (int b = thisStopIndex; b < thisDirCount; b++)
                        {
                            //每个到达的的站如果作为中转站
                            string ChangeStop = LineStopsTable.Rows[b][1].ToString();
                            string ChangeStartSql = "select * from buslines where BSName like '" + ChangeStop + "'";
                            MySqlDataAdapter ChangeAD = new MySqlDataAdapter(ChangeStartSql, connection_);
                            DataTable ChangeSTable = new DataTable();
                            ChangeAD.Fill(ChangeSTable);
                            int ChangeTCount = ChangeSTable.Rows.Count;
                            //搜寻经过这个中转站的路线
                            for (int c = 0; c < ChangeTCount; c++)
                            {
                                string ChangeStartLine = ChangeSTable.Rows[c][1].ToString();
                                int ChangeLineDir = int.Parse(ChangeSTable.Rows[c][4].ToString());
                                //搜寻经过终点站的路线
                                for (int d = 0; d < EndP.Rows.Count; d++)
                                {
                                    string EndStopLine = EndP.Rows[d][1].ToString();
                                    int EndStopLineDir = int.Parse(EndP.Rows[d][4].ToString());
                                    if (EndStopLine == ChangeStartLine && ChangeLineDir == EndStopLineDir)
                                    {
                                        FirstNum[R] = int.Parse(LineStopsTable.Rows[b][2].ToString()) - int.Parse(LineStopsTable.Rows[thisStopIndex - 1][2].ToString());
                                        //确认该条换乘路线的有经过终点
                                        string EndLineSQL = "select * from buslines where BLName='" + EndStopLine + "' and BLNote = " + EndStopLineDir;
                                        MySqlDataAdapter EndLineAD = new MySqlDataAdapter(EndLineSQL, connection_);
                                        DataTable EndLineTable = new DataTable();
                                        EndLineAD.Fill(EndLineTable);
                                        for (int t = 0; t < EndLineTable.Rows.Count; t++)
                                        {
                                            string ResultEndLineStop = EndLineTable.Rows[t][2].ToString();
                                            if (ResultEndLineStop == ChangeStop)
                                            {
                                                for (int t2 = t; t2 < EndLineTable.Rows.Count; t2++)
                                                {
                                                    string thisStop = EndLineTable.Rows[t2][2].ToString();
                                                    if (thisStop == endPName)
                                                    {
                                                        int thisSNum = int.Parse(LineStopsTable.Rows[thisStopIndex][2].ToString());
                                                        int thisCNum1 = int.Parse(LineStopsTable.Rows[b][2].ToString());
                                                        int thisCNum2 = int.Parse(EndLineTable.Rows[t][3].ToString());
                                                        int thisENum = int.Parse(EndLineTable.Rows[t2][3].ToString());
                                                        SecondNum[R] = int.Parse(EndLineTable.Rows[t2][3].ToString()) - int.Parse(EndLineTable.Rows[t][3].ToString());
                                                        FirstLine[R] = thisLine;
                                                        ChangeStopN[R] = ChangeStop;
                                                        SecondLine[R] = EndStopLine;
                                                        FirstDir[R] = i;
                                                        SecondDir[R] = EndStopLineDir;
                                                        SumStops[R] = FirstNum[R] + SecondNum[R];
                                                        BNStart[R] = thisSNum;
                                                        BNChange1[R] = thisCNum1;
                                                        BNChange2[R] = thisCNum2;
                                                        BNEnd[R] = thisENum;
                                                        BusAllText.Text = BusAllText.Text + "先" + FirstDir[R] + "方向上乘坐【" + FirstLine[R] + "】[" + FirstNum[R] + "]站到达【" + ChangeStopN[R] + "】后在" + SecondDir[R] + "方向上换乘【" + SecondLine[R] + "】[" + SecondNum[R] + "]站到达" + "\n";
                                                        R++;
                                                    }
                                                }
                                            }
                                        }
                                        EndLineTable.Clear();
                                    }
                                }
                            }
                            ChangeSTable.Clear();
                        }
                        LineStopsTable.Clear();
                    }
                }
                //判断哪条换乘线最适合
                for (int n = 1; n < R; n++)
                {
                    if (SumStops[n] < SumStops[MinR])
                        MinR = n;
                }
                BusCommandText.Text = BusCommandText.Text + "推荐换乘路线：" + "\n" + "先" + FirstDir[MinR] + "方向上乘坐【" + FirstLine[MinR] + "】[" + FirstNum[MinR] + "]站到达【" + ChangeStopN[MinR] + "】后在" + SecondDir[MinR] + "方向上换乘【" + SecondLine[MinR] + "】[" + SecondNum[MinR] + "]站到达";

                //**********************************************显示推荐线路************************************************
                //第一条
                if (R != 0)
                {
                    int startUse = BNStart[MinR];
                    if (BNStart[MinR] != 1)
                    {
                        startUse = BNStart[MinR] - 1;
                    }
                    string ShowDirSR = "select ID,N,E,Num,Note,BNum from buslinesshow where (BLName='" + FirstLine[MinR] + "') and (Note=" + FirstDir[MinR] + ") and (BNum in(" + startUse;
                    //如果只有一站
                    if (FirstNum[MinR] == 1)
                    {
                        ShowDirSR = ShowDirSR + "))";
                    }
                    //多个站
                    if (FirstNum[MinR] > 1)
                    {
                        for (int q = startUse + 1; q < BNChange1[MinR]; q++)
                        {
                            ShowDirSR = ShowDirSR + "," + q;
                        }
                        ShowDirSR = ShowDirSR + "))";
                    }
                    MySqlDataAdapter show1 = new MySqlDataAdapter(ShowDirSR, connection_);
                    DataTable showTable1 = new DataTable();
                    show1.Fill(showTable1);
                    int showCount = showTable1.Rows.Count;
                    for (int p = 0; p < showCount; p++)
                    {
                        N[p] = double.Parse(showTable1.Rows[p][1].ToString());
                        E[p] = double.Parse(showTable1.Rows[p][2].ToString());
                    }
                    //画点
                    int jungleStop = 0;
                    for (int k = 0; k < showCount; k++)
                    {
                        jungleStop = int.Parse(showTable1.Rows[k][3].ToString());
                        if (jungleStop == 1)
                        {
                            axMap1.DrawPointEx(linehandle, E[k], N[k], 8, 1);
                        }
                    }
                    axMap1.DrawPointEx(linehandle, E[showCount - 1], N[showCount - 1], 8, 1);
                    //画线
                    for (int n = 0; n < showCount - 1; n++)
                    {
                        axMap1.DrawLineEx(linehandle, E[n], N[n], E[n + 1], N[n + 1], 2, 1);
                    }

                    //第二条
                    int startUse2 = BNChange2[MinR];
                    //if (BNStart[MinR] != 1 && SecondNum[MinR] != 1)
                    //{
                    //    startUse2 = BNChange2[MinR] - 2;
                    //}
                    string ShowDirSR2 = "select ID,N,E,Num,Note,BNum from buslinesshow where (BLName='" + SecondLine[MinR] + "') and (Note=" + SecondDir[MinR] + ") and (BNum in(" + startUse2;
                    //如果只有一站
                    if (SecondNum[MinR] == 1)
                    {
                        ShowDirSR2 = ShowDirSR2 + "))";
                    }
                    //多个站
                    if (SecondNum[MinR] > 1)
                    {
                        for (int q = startUse2 + 1; q < BNEnd[MinR]; q++)
                        {
                            ShowDirSR2 = ShowDirSR2 + "," + q;
                        }
                        ShowDirSR2 = ShowDirSR2 + "))";
                    }
                    MySqlDataAdapter show2 = new MySqlDataAdapter(ShowDirSR2, connection_);
                    DataTable showTable2 = new DataTable();
                    show2.Fill(showTable2);
                    int showCount2 = showTable2.Rows.Count;
                    for (int p = 0; p < showCount2; p++)
                    {
                        N2[p] = double.Parse(showTable2.Rows[p][1].ToString());
                        E2[p] = double.Parse(showTable2.Rows[p][2].ToString());
                    }

                    //画点
                    int jungleStop2 = 0;
                    for (int k = 0; k < showCount2; k++)
                    {
                        jungleStop2 = int.Parse(showTable2.Rows[k][3].ToString());
                        if (jungleStop2 == 1)
                        {
                            axMap1.DrawPoint(E2[k], N2[k], 8, 200);
                        }
                    }
                    axMap1.DrawPointEx(linehandle, E2[showCount2 - 1], N2[showCount2 - 1], 8, 200);
                    //画线
                    for (int n = 0; n < showCount2 - 1; n++)
                    {
                        axMap1.DrawLineEx(linehandle, E2[n], N2[n], E2[n + 1], N2[n + 1], 2, 200);
                    }
                }

                if (R == 0)
                {
                    MessageBox.Show("路线超出大学城范围，建议转换其他方式或站点");
                }
            }
            #endregion

















        }
        private void button1_Click(object sender, EventArgs e)
        {
            axMap1.ClearDrawings();
        }
        #endregion



        #region 在图上选取点作为起终点
        private int PointF = 0;
        private void 选取起终点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointF = 1;
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
            axMap1.SendMouseDown = true;
        }

        private void axMap1_MouseDownEvent(object sender, AxMapWinGIS._DMapEvents_MouseDownEvent e)
        {
            if (PointF == 1 || PointF==3)
            {
                double xP = 0;
                double yP = 0;
                Shapefile sf = new Shapefile();
                bool result = sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);
                MapWinGIS.Point pt = new MapWinGIS.Point();
                axMap1.PixelToProj(e.x, e.y, ref xP, ref yP);
                pt.x = xP;
                pt.y = yP;
                comboBox1.Text = FindMinStop(xP, yP);
                Shape shp = new Shape();
                shp.Create(ShpfileType.SHP_POINT);
                shp.InsertPoint(pt, 0);
                sf.EditInsertShape(shp, 0);
                sf.DefaultDrawingOptions.SetDefaultPointSymbol(tkDefaultPointSymbol.dpsStar);
                axMap1.AddLayer(sf, true);
                axMap1.SendMouseDown = false;
            }
            if (PointF == 2 || PointF==4)
            {
                double xP = 0;
                double yP = 0;
                Shapefile sf = new Shapefile();
                bool result = sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);
                MapWinGIS.Point pt = new MapWinGIS.Point();
                axMap1.PixelToProj(e.x, e.y, ref xP, ref yP);
                pt.x = xP;
                pt.y = yP;
                comboBox2.Text = FindMinStop(xP, yP);
                Shape shp = new Shape();
                shp.Create(ShpfileType.SHP_POINT);
                shp.InsertPoint(pt, 0);
                sf.EditInsertShape(shp, 0);
                sf.DefaultDrawingOptions.SetDefaultPointSymbol(tkDefaultPointSymbol.dpsStar);
                axMap1.AddLayer(sf, true);
                axMap1.SendMouseDown = false;
            }



        }

        private string FindMinStop(double x, double y)
        {
            string minName="0";
            if (PointF == 2 || PointF == 1)
            {
                string Stopsaql = "select * from busstops";
                MySqlDataAdapter stopad = new MySqlDataAdapter(Stopsaql, connection_);
                DataTable StopsTable = new DataTable();
                stopad.Fill(StopsTable);

                int minID = 0;
                
                double minest = 10000;
                for (int i = 0; i < StopsTable.Rows.Count; i++)
                {
                    double x1 = double.Parse(StopsTable.Rows[i][3].ToString());
                    double y1 = double.Parse(StopsTable.Rows[i][2].ToString());
                    double sum = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
                    if (sum < minest)
                    {
                        minID = i;
                        minest = sum;
                    }
                }
                minName = StopsTable.Rows[minID][1].ToString();
            }

            else if (PointF == 3 || PointF == 4)
            {
                string Stopsaql = "select * from nodepoints";
                MySqlDataAdapter stopad = new MySqlDataAdapter(Stopsaql, connection_);
                DataTable StopsTable = new DataTable();
                stopad.Fill(StopsTable);

                int minID = 0;

                double minest = 10000;
                for (int i = 0; i < StopsTable.Rows.Count; i++)
                {
                    double x1 = double.Parse(StopsTable.Rows[i][3].ToString());
                    double y1 = double.Parse(StopsTable.Rows[i][2].ToString());
                    double sum = Math.Sqrt((x1 - x) * (x1 - x) + (y1 - y) * (y1 - y));
                    if (sum < minest)
                    {
                        minID = i;
                        minest = sum;
                    }
                }
                minName = StopsTable.Rows[minID][1].ToString();
            }

            return minName;
        }

        private void 选取终点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointF = 2;
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
            axMap1.SendMouseDown = true;
        }



        #endregion

        #region 驾车导航
        public DataTable LiTable = new DataTable();
        public DataTable ResTable = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            LiTable.Clear();
            ResTable.Clear();
            //选取离起终点最近的节点
            int startPID = int.Parse(comboBox1.Text.ToString());
            int EndPID = int.Parse(comboBox2.Text.ToString());

            string Search1 = "select N,E from nodepoints where NodeName = " + startPID;
            MySqlDataAdapter Psql1 = new MySqlDataAdapter(Search1, connection_);
            DataTable Ptable1 = new DataTable();
            Psql1.Fill(Ptable1);
            double np1 = double.Parse(Ptable1.Rows[0][0].ToString());
            double ep1 = double.Parse(Ptable1.Rows[0][1].ToString());

            string Search2 = "select N,E from nodepoints where NodeName = " + EndPID;
            MySqlDataAdapter Psql2 = new MySqlDataAdapter(Search2, connection_);
            DataTable Ptable2 = new DataTable();
            Psql2.Fill(Ptable2);
            double np2 = double.Parse(Ptable2.Rows[0][0].ToString());
            double ep2 = double.Parse(Ptable2.Rows[0][1].ToString());

            int thislinehandle = axMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            axMap1.DrawPoint(ep1, np1, 10, 100);
            axMap1.DrawPoint(ep2, np2, 10, 200);

            if (LiTable.Columns.Count == 0)
            {
                LiTable.Columns.Add("ID", typeof(int));
                LiTable.Columns.Add("FPID", typeof(int));
                LiTable.Columns.Add("LPID", typeof(int));
                LiTable.Columns.Add("RID", typeof(int));
                LiTable.Columns.Add("RELEVEL", typeof(int));
                LiTable.Columns.Add("DIS", typeof(double));
                LiTable.Columns.Add("NOTE", typeof(int));

                ResTable = LiTable.Clone();
            }
            //定义查找参数
            string SearchConnP;
            MySqlDataAdapter ConnPsql;
            DataTable ConnPtable;

            int i = 0;
            int thisLine = 0;
            int thisLineCount = 0;
            int thisRID = 0;
            int thisEID = 0;
            int thisRELEVEL = 0;
            double thisDIS = 0;
            int flag = 0;

            SearchConnP = "select * from nodeconn where Node1Name = " + startPID;
            ConnPsql = new MySqlDataAdapter(SearchConnP, connection_);
            ConnPtable = new DataTable();
            ConnPsql.Fill(ConnPtable);
            thisLineCount = ConnPtable.Rows.Count;
            int[] thislineID=new int[thisLineCount];
            //第一层
            for (int q = 0; q < thisLineCount; q++)
            {
                //判断此点是否与第一层同级的点或长辈级重复
                thisEID = int.Parse(ConnPtable.Rows[q][3].ToString());
                //判断是否为第一层第一个
                if (LiTable.Rows.Count != 0)
                {
                    for (int p = 0; p < LiTable.Rows.Count; p++)
                    {
                        if (thisEID == int.Parse(LiTable.Rows[p][1].ToString()))
                        {
                            flag = 0;
                            break;
                        }
                        else
                        { flag = 1; }
                    }
                }
                else
                { flag = 1; }

                //存放这个点和母级组成的线段
                if (flag == 1)
                {
                    thisRID = int.Parse(ConnPtable.Rows[q][0].ToString());
                    thisRELEVEL = int.Parse(ConnPtable.Rows[q][2].ToString());
                    thisDIS = double.Parse(ConnPtable.Rows[q][5].ToString());
                    LiTable.Rows.Add(thisLine, startPID, thisEID, thisRID, thisRELEVEL, thisDIS, i);
                    thisLine++;
                    thislineID[q]=thisEID;
                }
            }

            
            FindRoad(thisLineCount,thislineID,i,EndPID);

            //********************************************显示路线*****************************************************
            int[] resSID=new int[ResTable.Rows.Count+1];
            int[] resEID=new int[ResTable.Rows.Count];
            double[] showN = new double[ResTable.Rows.Count * 10];
            double[] showE = new double[ResTable.Rows.Count * 10];
            double LengthSum = 0;
            string showLine;
            MySqlDataAdapter showLineAD;
            DataTable showLineTable=new DataTable();
            int b=0;

            for ( int k = 0; k < ResTable.Rows.Count; k++)
            {
                resSID[k] = int.Parse(ResTable.Rows[k][1].ToString());
                resEID[k] = int.Parse(ResTable.Rows[k][2].ToString());
            }

            //获取显示的点坐标
            for (int k2 = ResTable.Rows.Count-1; k2 >= 0; k2--)
            {
                showLine = "select N,E from roadsshow where SID=" + resSID[k2] + " and EID=" + resEID[k2];
                showLineAD = new MySqlDataAdapter(showLine, connection_);
                showLineAD.Fill(showLineTable);

                //if (showLineTable.Rows.Count == 0)
                //{
                //    showLineTable.Clear();
                //    showLineAD.Dispose();
                //    showLine = "select N,E from nodepoints where NodeName=" + resSID[k2] + " or NodeName=" + resEID[k2];
                //    showLineAD = new MySqlDataAdapter(showLine, connection_);
                //    showLineAD.Fill(showLineTable);
                //}

                for (int k3 = 0; k3 < showLineTable.Rows.Count; k3++)
                {
                    showN[b] = double.Parse(showLineTable.Rows[k3][0].ToString());
                    showE[b] = double.Parse(showLineTable.Rows[k3][1].ToString());
                    b++;
                }
                showLineTable.Clear();
            }
            //resSID[ResTable.Rows.Count] = int.Parse(ResTable.Rows[ResTable.Rows.Count - 1][2].ToString());
            //for (int k2 = 0; k2 <= ResTable.Rows.Count; k2++)
            //{
            //    showLine = "select N,E from nodepoints where NodeName=" + resSID[k2];
            //    showLineAD = new MySqlDataAdapter(showLine, connection_);
            //    showLineAD.Fill(showLineTable);
            //    showN[b] = double.Parse(showLineTable.Rows[0][0].ToString());
            //    showE[b] = double.Parse(showLineTable.Rows[0][1].ToString());
            //    b++;
            //    showLineAD.Dispose();
            //    showLineTable.Clear();

            //}

            int linehandle = axMap1.NewDrawing(MapWinGIS.tkDrawReferenceList.dlSpatiallyReferencedList);
            for (int n = 0; n < b-1; n++)
            {
                axMap1.DrawLineEx(linehandle, showE[n], showN[n], showE[n + 1], showN[n + 1], 3, 1);
            }

            for (int p = 0; p < ResTable.Rows.Count; p++)
            {
                LengthSum =LengthSum +double.Parse(ResTable.Rows[p][5].ToString()) ;
            }
            BusCommandText.Text = "总长度为：" + LengthSum + "米";

            tableshow fm2 = new tableshow(this);
            fm2.ShowDialog();
                
            }




            private void FindRoad(int count,int[] SID,int i,int EndP)
            {
                int flag=0;
                int flag2=0;
                int thisLineCount=0;
                int thisEID=0;
                int thisRID=0;
                int thisRELEVEL=0;
                double thisDIS=0;
                int thisLine=int.Parse(LiTable.Rows.Count.ToString());
                i++;
                int i2=0;

                int[] SIDCount = new int[4 * count];
                int[] FIDCount = new int[4 * count];
                int sumCount = 0;

                for (int n = 0; n < count; n++)
                {
                    string SearchConnP = "select * from nodeconn where Node1Name = " + SID[n];
                    MySqlDataAdapter ConnPsql = new MySqlDataAdapter(SearchConnP, connection_);
                    DataTable ConnPtable = new DataTable();
                    ConnPsql.Fill(ConnPtable);
                    thisLineCount = ConnPtable.Rows.Count;
                    sumCount = sumCount + thisLineCount;
                    for (int q = 0; q < thisLineCount; q++)
                    {
                        //判断此点是否与长辈级的点重复
                        thisEID = int.Parse(ConnPtable.Rows[q][3].ToString());
                        for (int p = 0; p < LiTable.Rows.Count; p++)
                        {
                            if (thisEID == int.Parse(LiTable.Rows[p][2].ToString()))
                            {
                                flag = 0;
                                break;
                            }
                            else
                            { flag = 1; }
                        }

                        //存放这个点和母级组成的线段
                        if (flag == 1)
                        {
                            thisRID = int.Parse(ConnPtable.Rows[q][0].ToString());
                            thisRELEVEL = int.Parse(ConnPtable.Rows[q][2].ToString());
                            thisDIS = double.Parse(ConnPtable.Rows[q][5].ToString());
                            LiTable.Rows.Add(thisLine, SID[n], thisEID, thisRID, thisRELEVEL, thisDIS, i);
                            thisLine++;
                            SIDCount[i2] = thisEID;
                            FIDCount[i2] = SID[n];
                            i2++;
                        }
                    }
                }

                for (int a = 0; a < sumCount; a++)
                {
                    if (SIDCount[a] == EndP)
                    {
                        flag2 = 1;
                        break;
                    }
                    else if (SIDCount[a] != EndP)
                    { flag2 = 0; }
                }

                if (flag2==0)
                {
                    FindRoad(sumCount, SIDCount, i, EndP);
                    int[] result = new int[0];
                }
                else if(flag2==1)
                {
                    int[] resultID = new int[i + 11];
                    resultID[i + 1] = EndP;
                    int thisEPID = EndP;
                    for (int i3 = i; i >= 0; i--)
                    {
                        string select = "LPID=" + thisEPID;
                        DataRow[] drr = LiTable.Select(select);
                        foreach (DataRow dr in drr)
                        {
                            thisEPID = int.Parse(dr["FPID"].ToString());
                            ResTable.ImportRow(dr);
                        }
                        //resultID[i3] = thisEPID;
                    }
                    ResTable.DefaultView.Sort = "ID asc";


                }

                       
                   
            }

            private void 选取起点ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                PointF = 3;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
                axMap1.SendMouseDown = true;

            }

            private void 选取终点ToolStripMenuItem1_Click(object sender, EventArgs e)
            {
                PointF = 4;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
                axMap1.SendMouseDown = true;

            }
        #endregion

    }
    }














