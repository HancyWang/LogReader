using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogReader
{
    public partial class Form1 : Form
    {
        public string SW_VERSION = "1.0.0";

        //现在没有真实数据，模拟假数据
        public const bool GENERATE_SIMU_DATA = false;
        public byte simu_code = 0;

        //配置文件(强制1字节对齐)
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SYS_CFG
        {
            public byte language;
        }
        //public SYS_CFG sys_cfg = new SYS_CFG();

        //配置文件路径
        private string m_cfg_file_path = Environment.CurrentDirectory + @"\" + "cfg.ini";
        #region
        public const byte ALARM_CODE_E1 = 0;
        public const byte ALARM_CODE_E2 = 1;
        public const byte ALARM_CODE_E3 = 2;
        public const byte ALARM_CODE_E4 = 3;
        public const byte ALARM_CODE_E5 = 4;
        public const byte ALARM_CODE_E6 = 5;
        public const byte ALARM_CODE_E7 = 6;
        public const byte ALARM_CODE_E8 = 7;
        public const byte ALARM_CODE_E9 = 8;
        public const byte ALARM_CODE_E10 = 9;
        public const byte ALARM_CODE_E11 = 10;
        public const byte ALARM_CODE_E12 = 11;
        public const byte ALARM_CODE_E13 = 12;
        public const byte ALARM_CODE_E14 = 13;
        public const byte ALARM_CODE_E15 = 14;
        public const byte ALARM_CODE_E16 = 15;
        public const byte ALARM_CODE_E17 = 16;
        public const byte ALARM_CODE_E18 = 17;
        public const byte ALARM_CODE_E19 = 18;
        public const byte ALARM_CODE_E20 = 19;
        public const byte ALARM_CODE_HIGH_TEMPERATURE = 20;
        public const byte ALARM_CODE_POWER_OFF = 21;
        public const byte ALARM_CODE_CHECK_CHAMBER = 22;
        public const byte ALARM_CODE_LACK_OF_WATER = 23;
        public const byte ALARM_CODE_TEMP_PROBE_UNINSTALLED = 24;
        public const byte ALARM_CODE_TUBE_UNINSTALLED = 25;
        public const byte ALARM_CODE_TUBE_NOT_MATCH = 26;
        public const byte ALARM_CODE_CHECK_BLOCKAGES = 27;
        public const byte ALARM_CODE_HIGH_O2CON = 28;
        public const byte ALARM_CODE_LOW_O2CON = 29;
        public const byte ALARM_CODE_FLOW_OVERRANGE = 30;
        public const byte ALARM_CODE_TEMP_OVERRANGE = 31;
        public const byte ALAMR_CODE_TEMP_RPROBE_OUT = 32;
        public const byte ALARM_CODE_SD_UNINSTALLED = 33;
        public const byte ALARM_CODE_CIRCUIT_FAILURE_DATA_CABLE_UNINSTALLED = 34;
        public const byte ALARM_CODE_CHECK_LEAK = 35;
        public const byte ALARM_CODE_LOW_BAT_CAPACITY = 36;
        public const byte ALARM_CODE_CANT_REACH_TARGET_O2CON = 37;
        public const byte ALARM_CODE_E21 = 38;
        public const byte ALARM_CODE_E22 = 39;
        public const byte ALARM_CODE_E23 = 40;
        public const byte ALARM_CODE_E24 = 41;
        public const byte ALARM_CODE_E25 = 42;
        public const byte ALARM_CODE_E26 = 43;
        public const byte ALARM_CODE_E27 = 44;
        public const byte ALARM_CODE_E28 = 45;
        public const byte ALARM_CODE_E29 = 46;
        public const byte ALARM_CODE_E30 = 47;
        public const byte ALARM_CODE_E31 = 48;
        public const byte ALARM_CODE_E32 = 49;
        #endregion

        public const int DEVICE_O2FLO = 1;
        public const int DEVICE_O2FLO_PRO = 2;
        public const int DEVICE_ID = DEVICE_O2FLO;

        //数据链表
        public List<LOG_INFO> m_list_logInfo = new List<LOG_INFO>();

        //数据管理(首页，上一页，下一页，尾页)
        public int m_total_page = 0;
        public int m_curr_page = 0;
        public int m_start_index = 0;
        public int m_end_index = 0;
        public const int m_PAGE_SIZE = 35;  //每一页的大小(每一页显示多少条数据)
        

        //LOG类型定义
        public const byte LOG_TYPE_ALARM = 1;           //alarm
        public const byte LOG_TYPE_NONE_ACTIVE = 2;     //非激活状态
        public const byte LOG_TYPE_OP_RECORD = 3;       //操作记录
        public const byte LOG_TYPE_PRE_USE_CHECK = 4;   //pre-use check
        public const byte LOG_TYPE_24_SWITCH = 5;       //切换供电电源

        //1.LOG类型之-"alarm"
        public const byte ALARM_PRIORITY_MEDIUM = 1;
        public const byte ALARM_PRIORITY_HIGH = 2;
        public class LOG_ALARM
        {
            public byte ALARM_CODE;
            public byte ALARM_DATA_L;
            public byte ALARM_DATA_H;
            public byte ALARM_PRIORITY_VAL;
        }

        //2.LOG类型之-"非激活状态"
        public const byte NOT_ACTIVE_AlarmSoundPause = 1;
        public class LOG_NOT_ACTIVE
        {
            public byte NOT_ACTIVE_CODE;
        }

        //3.LOG类型之-"操作记录"
        public byte OP_RECORD_BLENDER_M_EXIST = 1;
        public byte OP_RECORD_BLENDER_A_EXIST = 2;

        public byte OP_RECORD_OpCode_INIT_SET = 1; //开机后的初始设置
        public byte OP_RECORD_OpCode_ALARM_SET_CHANGE = 2; //报警设置改变
        public byte OP_RECORD_OpCode_SET_PARA_CHANGE = 3;  //治疗参数改变

        public const byte MODE_BABY = 0;        //儿童
        public const byte MODE_ADULT = 1;       //成人

        public byte OP_RECORD_OPChangeCode_ADULT_BABY_MODE = 1;
        public byte OP_RECORD_OPChangeCode_TEMP_SET = 2;
        public byte OP_RECORD_OPChangeCode_FLOW_SET = 3;
        public byte OP_RECORD_OPChangeCode_HighO2ConAlarm_SET = 4;
        public byte OP_RECORD_OPChangeCode_LowO2ConAlarm_SET = 5;
        public byte OP_RECORD_OPChangeCode_O2Con_SET = 6;
        public byte OP_RECORD_OPChangeCode_TREAATMENT_MODE_CHANGE = 7;

        //工作状态
        //1-关机 2-开机自检 3-PreUse check 4-暂停 5-运行 6-转运模式运行 7-冷却模式 8-低流量模式暂停  9-低流量模式运行 
        public const byte OP_WorkState_POWER_OFF = 1;
        public const byte OP_WorkState_SELFCHECK = 2;
        public const byte OP_WorkState_PREUSE_CHECK = 3;
        public const byte OP_WorkState_PAUSE = 4;
        public const byte OP_WorkState_RUN = 5;
        public const byte OP_WorkState_TARNSPORT_MODE = 6;
        public const byte OP_WorkState_COOLING_DOWN_MODE = 7;
        public const byte OP_WorkState_LOWFLOW_MODE_PAUSE = 8;
        public const byte OP_WorkState_LOWFLOW_MODE_RUN = 9;

        //4.Pre-use check
        public const byte PRE_USE_CHECK_PASS = 1;
        public const byte PRE_USE_CHECK_FAIL = 2;
        public class LOG_PRE_USE_CHECK
        {
            public byte check_result;
            public byte _6Pin_circle_type_L;
            public byte _6Pin_circle_type_H;
            public byte temp_patient;
            public byte temp_outlet;
            public byte temp_ambient;
            public byte circle_resitor_val; //回路电阻
            public byte WATER_LEVEL_SENSOR_HADC_L;
            public byte WATER_LEVEL_SENSOR_HADC_H;
            public byte WATER_LEVEL_SENSOR_LADC_L;
            public byte WATER_LEVEL_SENSOR_LADC_H;
            public byte LEAK_CHECK_VAL;         //泄露检测
        }

        //5.切换供电电源
        public const byte _24V_CODE_SOURCE_CHANGED = 1;
        public const byte _24V_FORM_AC = 1;
        public const byte _24V_FROM_BAT = 2;
        public class LOG_24V_STATE
        {
            public byte code;
            public byte change_before_val;
            public byte change_after_val;
        }

        public class LOG_OP_RECORD
        {
            public byte OP_CODE;
            public byte CHANGE_CODE;
            public byte OP_CHANGE_BEFORE_VAL;
            public byte OP_CHANGE_AFTER_VAL;
            public byte MODE_AND_TIME;
            public byte SET_TEMPERATURE;        //设定温度
            public byte SET_FLOW;               //设定流量
            public byte SET_HIGH_O2CON_ALARM;   //设定高氧浓度报警
            public byte SET_LOW_O2CON_ALARM;    //设定低氧浓度报警
            public byte SET_ADULT_OR_BABY;      //设定成人儿童模式
            public byte BLENDER_A_M;            //氧模块状态
            public byte SET_O2_CON;             //设置氧浓度
        }

        

        //低压氧模块状态
        public const byte LOG_INFO_BLENDER_M_EXIST = 1;
        public const byte LOG_INFO_BLENDER_M_NOT_EXIST = 2;
        //高压氧模块通信标志
        public const byte LOG_INFO_BLENDER_A_COMM_OK = 1;
        public const byte LOG_INFO_BLENDER_A_COMM_FAIL = 2;
        //设定24V供电
        public const byte LOG_INFO_24V_FROM_AC = 1;
        public const byte LOG_INFO_24V_FROM_BAT = 2;
        //空氧板流量传感器类型
        public const byte LOG_INFO_BLENDER_FLOW_SENSOR_MF2040 = 1;
        public const byte LOG_INFO_BLENDER_FLOW_SENSOR_MF2070 = 2;
        public const byte LOG_INFO_BLENDER_FLOW_SENSOR_SFM3000 = 3;
        public const byte LOG_INFO_BLENDER_FLOW_SENSOR_SDP800 = 4;

        public struct LOG_INFO
        {
            public byte LOG_DEF_L;      //log的定义
            public byte LOG_DEF_H;
            public byte START_YEAR_L;   //开始的年月日时分秒
            public byte START_YEAR_H;
            public byte START_MONTH;
            public byte START_DAY;
            public byte START_HOUR;
            public byte START_MIN;
            public byte START_SECOND;
            public byte END_YEAR_L;   //结束的年月日时分秒
            public byte END_YEAR_H;
            public byte END_MONTH;
            public byte END_DAY;
            public byte END_HOUR;
            public byte END_MIN;
            public byte END_SECOND;
            public byte WORK_STATE; //工作状态
            public byte MODE_AND_TIME;  //模式和时间 低1位 0-湿化 1-低流量，高5位为设置时间5-30分钟
            public byte SET_TEMPERATURE;        //设定温度
            public byte SET_FLOW;               //设定流量
            public byte SET_HIGH_O2CON_ALARM;   //设定高氧浓度报警
            public byte SET_LOW_O2CON_ALARM;    //设定低氧浓度报警
            public byte SET_ADULT_OR_BABY;      //设定成人儿童模式
            public byte SET_O2_CON;             //设置氧浓度(仅自动模块有效,手动无效)
            public byte Temp_patient_rt;        //患者端实时温度
            public byte Temp_outlet_rt;         //出气口实时温度
            public byte Temp_heatingPlate_rt;   //加热盘实时温度
            public byte Temp_ambient_rt;        //环境实时温度
            public byte Temp_driver_board;      //驱动板温度
            public byte TOTAL_FLOW_RT;          //实时流量
            public byte O2_CON_RT;              //实时氧浓度
            public byte _6Pin_CIRCLE_TYPE_L;    //回路类型L
            public byte _6Pin_CIRCLE_TYPE_H;    //回路类型H
            public byte BLOWER_SPEED_L;         //主马达转速数值L
            public byte BLOWER_SPEED_H;         //主马达转速数值H
            public byte PRESSURE_L;             //气道压力L
            public byte PRESSURE_H;             //气道压力H
            public byte WATER_LEVEL_HADC_L;     //水位，湿化罐
            public byte WATER_LEVEL_HADC_H;
            public byte WATER_LEVEL_LADC_L;
            public byte WATER_LEVEL_LADC_H;
            public byte COOLING_FAN_PWM_L;      //散热风扇驱动数值(PWM)
            public byte COOLING_FAN_PWM_H;
            public byte COOLING_FAN_SPEED_L;    //散热风扇驱动数值(转速)
            public byte COOLING_FAN_SPEED_H;
            public byte BLOWER_TEMPERATUR_L;    //主马达实时温度
            public byte BLOWER_TEMPERATUR_H;
            public byte DEW_POINT_TEMPERATUR;   //露点温度
            public byte Temp_O2Con_rt_L;        //气道实时温度(氧传感器)
            public byte Temp_O2Con_rt_H;
            public byte BAT_CAP_PERCENT;        //电池电量百分比
            public byte O2_FLOW_RT;             //实时氧流量
            public byte VOLT_MLB_5V;             //主控板5V电压
            public byte VOLT_DRIVER_24V_L;        //驱动板24V电压
            public byte VOLT_DRIVER_24V_H;
            public byte VOLT_DRIVER_12V;        //驱动板12V电压
            public byte VOLT_DRIVER_5V;         //驱动板5V电压
            public byte VOLT_BLENDER_12V;       //空氧混合板12V电压
            public byte VOLT_BLENDER_5V;        //空氧混合板5V电压
            public byte BLOWER_ERR_CODE;        //主风机故障码
            public byte TEMP_CONTROLLER_STATE;  //温控器状态
            public byte HEATING_PLATE_STATE;    //发热盘状态
            public byte BLENDER_CURRENT_L;      //比例阀工作电流
            public byte BLENDER_CURRENT_H;
            public byte VOLT_AC_L;                //市电电压
            public byte VOLT_AC_H;
            public byte BLENDER_M_STATE;        //低压氧模块状态 1-检测到模块 2-未检测到模块
            public byte BLENDER_A_COMM_FLG;     //Blener模块(高压氧)通信标志
            public byte _24V_SOURCE_FLG;        //设定24V供电
            public byte Temp_Blender_L;         //比例阀温度
            public byte Temp_Blender_H;
            public byte BLENDER_FLOW_SENSOR_TYPE;   //空氧板流量传感器类型
            public byte RESERVE_72;         //预留
            public byte RESERVE_73;
            public byte RESERVE_74;
            public byte RESERVE_75;
            public byte RESERVE_76;
            public byte RESERVE_77;
            public byte RESERVE_78;
            public byte RESERVE_79;
            public byte DATA_80;
            public byte DATA_81;
            public byte DATA_82;
            public byte DATA_83;
            public byte DATA_84;
            public byte DATA_85;
            public byte DATA_86;
            public byte DATA_87;
            public byte DATA_88;
            public byte DATA_89;
            public byte DATA_90;
            public byte DATA_91;
            public byte DATA_92;
            public byte DATA_93;
            public byte DATA_94;
            public byte DATA_95;
            public byte DATA_96;
            public byte DATA_97;
            public byte DATA_98;
            public byte DATA_99;
            public byte DATA_100;
            public byte DATA_101;
            public byte DATA_102;
            public byte DATA_103;
            public byte DATA_104;
            public byte DATA_105;
            public byte DATA_106;
            public byte DATA_107;
            public byte DATA_108;
            public byte DATA_109;
            public byte DATA_110;
            public byte DATA_111;
            public byte DATA_112;
            public byte DATA_113;
            public byte DATA_114;
            public byte DATA_115;
            public byte DATA_116;
            public byte DATA_117;
            public byte DATA_118;
            public byte DATA_119;
            public byte DATA_120;
            public byte DATA_121;
            public byte DATA_122;
            public byte DATA_123;
            public byte DATA_124;
            public byte DATA_125;
            public byte CHECKSUM_L;
            public byte CHECKSUM_H;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //模拟生成假数据
            if (GENERATE_SIMU_DATA == true)
            {
                if (Directory.Exists("C:/Users/Administrator/Desktop/SD_TEST/170000000001"))
                {
                    string[] strPathes = Directory.GetFiles("C:/Users/Administrator/Desktop/SD_TEST/170000000001", "*.vmf");
                    foreach (var path in strPathes)
                    {
                        File.Delete(path);
                    }
                    //Directory.Delete("C:/Users/Administrator/Desktop/SD_TEST/170000000001");
                }

                DateTime tmBegin = new DateTime(2022, 1, 1, 0, 0, 0);
                //产生多少天数据
                //Int32 duration = 365 * 2;
                CreateLoggingFile(tmBegin);
                
            }
            //读取配置文件
            red_cfg_file();
            
            //更新UI界面上的文字
            update_UI_by_language();

            //listView
            Init_listView_log();
        }

        private void red_cfg_file()
        {
            if (File.Exists(m_cfg_file_path))
            {
                FileStream fs = new FileStream(m_cfg_file_path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs, Encoding.ASCII);

                int size = Marshal.SizeOf<SYS_CFG>();  //强制1字节对齐

                byte[] buffer = new byte[size];

                br.Read(buffer, 0, size); //读取数据到buffer中

                SYS_CFG sys_cfg = GetObject<SYS_CFG>(buffer, size);  //转换成结构体

                //系统语言
                LanguageMngr.m_lang = (LanguageMngr.LANGUAGE)sys_cfg.language;

                br.Close();
                fs.Close();
            }
            else
            {
                //没有文件，就采用默认设置

                //系统语言
                LanguageMngr.m_lang = LanguageMngr.LANGUAGE.ENGLISH;
            }
                
        }

        private void Init_listView_log()
        {
            this.listView_log.Items.Clear();
            listView_log.Columns.Clear();
            listView_log.View = View.Details;
            this.listView_log.Columns.Add("No.", 50, HorizontalAlignment.Left);                       
            this.listView_log.Columns.Add(LanguageMngr.log_type(), 100, HorizontalAlignment.Left);
            this.listView_log.Columns.Add(LanguageMngr.start_time(), 140, HorizontalAlignment.Left);
            this.listView_log.Columns.Add(LanguageMngr.end_time(), 140, HorizontalAlignment.Left);
            this.listView_log.Columns.Add(LanguageMngr.Logging_record(), 1200, HorizontalAlignment.Left);
        }

        private void CreateLoggingFile(DateTime tmBegin)
        {
            //产生Logging文件
            string strFilePath = "C:/Users/LENOVO/Desktop/SD_TEST/170000000001/Logging.vmf";
            string strData = Convert.ToString(tmBegin.Year) + Convert.ToString(tmBegin.Month).PadLeft(2, '0') + Convert.ToString(tmBegin.Day).PadLeft(2, '0');

            FileStream fs = new FileStream(strFilePath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.ASCII);

            #region
            //0.文件识别码
            byte[] file_mark = new byte[128] ;
            file_mark[0] = Convert.ToByte(5);
            file_mark[1] = Convert.ToByte('L');
            file_mark[2] = Convert.ToByte('O');
            file_mark[3] = Convert.ToByte('G');
            file_mark[4] = Convert.ToByte('G');
            file_mark[5] = Convert.ToByte('I');
            file_mark[6] = Convert.ToByte('N');
            file_mark[7] = Convert.ToByte('G');
            bw.Write(file_mark, 0, 128);
            //1.机型号
            byte[] mathine_type = new byte[128];
            mathine_type[0] = Convert.ToByte(6);
            mathine_type[1] = Convert.ToByte('V');
            mathine_type[2] = Convert.ToByte('U');
            mathine_type[3] = Convert.ToByte('N');
            mathine_type[4] = Convert.ToByte('0');
            mathine_type[5] = Convert.ToByte('0');
            mathine_type[6] = Convert.ToByte('1');
            bw.Write(mathine_type, 0, 128);
            //2.SN
            byte[] SN = new byte[128];
            SN[0] = Convert.ToByte(10);
            SN[1] = Convert.ToByte('1');
            SN[2] = Convert.ToByte('7');
            SN[3] = Convert.ToByte('0');
            SN[4] = Convert.ToByte('0');
            SN[5] = Convert.ToByte('0');
            SN[6] = Convert.ToByte('0');
            SN[7] = Convert.ToByte('0');
            SN[8] = Convert.ToByte('0');
            SN[9] = Convert.ToByte('0');
            SN[10] = Convert.ToByte('0');
            bw.Write(SN, 0, 128);
            //3.软件版本
            byte[] software_ver = new byte[128];
            software_ver[0] = Convert.ToByte(3);
            software_ver[1] = Convert.ToByte(1);
            software_ver[2] = Convert.ToByte(0);
            software_ver[3] = Convert.ToByte(2);
            bw.Write(software_ver, 0, 128);
            //4.LOGGING文件版本号
            byte[] log_ver = new byte[128];
            log_ver[0] = Convert.ToByte(3);
            log_ver[1] = Convert.ToByte(1);
            log_ver[2] = Convert.ToByte(0);
            log_ver[3] = Convert.ToByte(0);
            bw.Write(log_ver, 0, 128);
            //5-14保留
            byte[] reserve = new byte[128];
            for (int i = 5; i <= 14; i++)
            {
                bw.Write(reserve, 0, 128);
            }
            //15-logging信息条数n  (这条没什么用)
            byte[] log_cnt = new byte[128];
            log_cnt[0] = Convert.ToByte(6);
            log_cnt[1] = Convert.ToByte(0);
            log_cnt[2] = Convert.ToByte(0);
            log_cnt[3] = Convert.ToByte(0);
            log_cnt[4] = Convert.ToByte(0);
            bw.Write(log_ver, 0, 128);
            #endregion

            //16-n-信息内容

            //先产生2000条试一试
            for (int i = 0; i < 2000; i++)
            {
                LOG_INFO log_info = new LOG_INFO();
                byte log_type = 0;
                //if (i == 120 || i == 600 || i == 1500)
                //{
                //    log_type = LOG_TYPE_PRE_USE_CHECK;
                //}
                //else if (i % 500 == 0)
                //{
                //    log_type = LOG_TYPE_NONE_ACTIVE;
                //}
                //else if (i % 99 == 0)
                //{
                //    log_type = LOG_TYPE_OP_RECORD;
                //}
                //else if (i == 1100 || i == 1900)
                //{
                //    log_type = LOG_TYPE_24_SWITCH;
                //}
                //else
                //{
                //    log_type = LOG_TYPE_ALARM;
                //}
                log_type = LOG_TYPE_OP_RECORD;

                log_info.LOG_DEF_L = Convert.ToByte(log_type % 256);
                log_info.LOG_DEF_H = Convert.ToByte(log_type / 256);

                //开始时间和结束时间
                log_info.START_YEAR_L = 2022 % 256;
                log_info.START_YEAR_H = 2022 / 256;
                log_info.START_MONTH = 1;
                log_info.START_DAY = 1;
                log_info.START_HOUR = 12;
                log_info.START_MIN = 10;
                log_info.START_SECOND = 20;

                log_info.END_YEAR_L = 2022 % 256;
                log_info.END_YEAR_H = 2022 / 256;
                log_info.END_MONTH = 1;
                log_info.END_DAY = 2;
                log_info.END_HOUR = 5;
                log_info.END_MIN = 1;
                log_info.END_SECOND = 25;

               
                Random rnd_val = new Random();
                log_info.WORK_STATE = Convert.ToByte(new Random().Next(OP_WorkState_POWER_OFF, OP_WorkState_LOWFLOW_MODE_RUN));   //工作状态
                log_info.MODE_AND_TIME = generate_mode_and_time(new Random().Next(0, 1));        //设置(模式和时间)
                log_info.SET_TEMPERATURE = Convert.ToByte(new Random().Next(31, 37));            //设定温度,31-37度
                log_info.SET_FLOW = Convert.ToByte(new Random().Next(2, 60));                    //设定流量,2-60度
                log_info.SET_HIGH_O2CON_ALARM= Convert.ToByte(new Random().Next(26, 95));        //设定高氧浓度报警,26%-95%
                log_info.SET_LOW_O2CON_ALARM = Convert.ToByte(new Random().Next(18, 91));        //设定低氧浓度报警,18%-91%
                log_info.SET_ADULT_OR_BABY= Convert.ToByte(new Random().Next(0, 1));             //设定成人儿童模式,0-成人 1-儿童
                log_info.SET_O2_CON = Convert.ToByte(new Random().Next(21, 100));                //设置氧浓度
                log_info.Temp_patient_rt = Convert.ToByte(rnd_val.Next(0, 60));             //患者端实时温度
                log_info.Temp_outlet_rt = Convert.ToByte(rnd_val.Next(0, 60));              //出气口实时温度
                log_info.Temp_heatingPlate_rt = Convert.ToByte(rnd_val.Next(0, 100));       //加热盘实时温度
                log_info.Temp_ambient_rt = Convert.ToByte(rnd_val.Next(0, 100));            //环境实时温度
                log_info.Temp_driver_board = Convert.ToByte(rnd_val.Next(0, 100));          //驱动板温度
                log_info.TOTAL_FLOW_RT = Convert.ToByte(rnd_val.Next(0, 80));               //实时流量
                log_info.O2_CON_RT = Convert.ToByte(rnd_val.Next(0, 99));                   //实时氧浓度
                log_info._6Pin_CIRCLE_TYPE_L = 21 % 256;                                    //回路类型
                log_info._6Pin_CIRCLE_TYPE_H = 21 / 256;
                int speed = rnd_val.Next(0, 65500);
                log_info.BLOWER_SPEED_L = Convert.ToByte(speed % 256);                      //主马达转速数值
                log_info.BLOWER_SPEED_H = Convert.ToByte(speed / 256);
                int pressure_val= rnd_val.Next(0, 100);
                log_info.PRESSURE_L = Convert.ToByte(pressure_val % 256);                   //气道压力
                log_info.PRESSURE_H = Convert.ToByte(pressure_val / 256);
                log_info.WATER_LEVEL_HADC_H = 0;                                            //水位传感器
                log_info.WATER_LEVEL_HADC_L = 0;
                log_info.WATER_LEVEL_LADC_H = 0;
                log_info.WATER_LEVEL_LADC_L = 0;
                log_info.COOLING_FAN_PWM_L = 0;                                             //散热风扇驱动数值(PWM)
                log_info.COOLING_FAN_PWM_H = 0;
                log_info.COOLING_FAN_SPEED_L = 0;                                           //散热风扇转速数值
                log_info.COOLING_FAN_SPEED_H = 0;
                log_info.BLOWER_TEMPERATUR_L = 0;                                           //主马达实时温度
                log_info.BLOWER_TEMPERATUR_H = 0;
                log_info.DEW_POINT_TEMPERATUR = Convert.ToByte(rnd_val.Next(0, 60));        //露点温度
                log_info.Temp_O2Con_rt_L = 0;                                               //气道实时温度(氧传感器)
                log_info.Temp_O2Con_rt_H = 0;
                log_info.BAT_CAP_PERCENT = Convert.ToByte(rnd_val.Next(0, 100));            //电量百分比
                log_info.VOLT_MLB_5V = Convert.ToByte(rnd_val.Next(46, 51));                //主控板5V电压
                int dirver_24V_val = rnd_val.Next(230, 245);
                log_info.VOLT_DRIVER_24V_L = Convert.ToByte(dirver_24V_val % 256);           //驱动板24V电压
                log_info.VOLT_DRIVER_24V_H = Convert.ToByte(dirver_24V_val / 256);
                log_info.VOLT_DRIVER_12V = Convert.ToByte(rnd_val.Next(118, 125));           //驱动板12V电压
                log_info.VOLT_DRIVER_5V = Convert.ToByte(rnd_val.Next(45, 53));              //驱动板5V电压
                log_info.VOLT_BLENDER_12V = Convert.ToByte(rnd_val.Next(118, 125));          //空氧混合板12V电压
                log_info.VOLT_BLENDER_5V = Convert.ToByte(rnd_val.Next(45, 53));             //空氧混合板5V电压
                log_info.BLOWER_ERR_CODE = Convert.ToByte(rnd_val.Next(0, 255));             //主风机状态-故障码
                log_info.TEMP_CONTROLLER_STATE = Convert.ToByte(rnd_val.Next(0, 1));         //温控器状态
                log_info.HEATING_PLATE_STATE = Convert.ToByte(rnd_val.Next(0, 1));           //发热盘状态
                int blender_curr = rnd_val.Next(0, 500);
                log_info.BLENDER_CURRENT_L = Convert.ToByte(blender_curr % 256);             //比例阀工作电流
                log_info.BLENDER_CURRENT_H = Convert.ToByte(blender_curr / 256);
                int AC_val = rnd_val.Next(216, 225);
                log_info.VOLT_AC_L = Convert.ToByte(AC_val % 256);                           //市电电压
                log_info.VOLT_AC_H = Convert.ToByte(AC_val / 256);
                log_info.BLENDER_M_STATE = Convert.ToByte(rnd_val.Next(1, 2));              //低压氧模块状态
                log_info.BLENDER_A_COMM_FLG = Convert.ToByte(rnd_val.Next(1, 2));           //Blener模块(高压氧)通信标志
                log_info._24V_SOURCE_FLG = Convert.ToByte(rnd_val.Next(1, 2));              //设定24V供电
                int blender_temp = rnd_val.Next(320, 562);
                log_info.Temp_Blender_L = Convert.ToByte(blender_temp % 256);               //比例阀温度
                log_info.Temp_Blender_H = Convert.ToByte(blender_temp / 256);
                log_info.BLENDER_FLOW_SENSOR_TYPE = Convert.ToByte(rnd_val.Next(1, 4));     //空氧板流量传感器类型

                //如果log类型是"ALARM"
                if (log_info.LOG_DEF_L + 256 * log_info.LOG_DEF_H == LOG_TYPE_ALARM)
                {
                    LOG_ALARM log_alarm = new LOG_ALARM();
                    simu_code++;
                    if (simu_code > 49)
                    {
                        simu_code = 0;
                    }
                    //log_alarm.ALARM_CODE = Convert.ToByte(rnd_val.Next(0, 49));
                    log_alarm.ALARM_CODE = simu_code;
                    log_alarm.ALARM_DATA_L = 0;
                    log_alarm.ALARM_DATA_H = 0;
                    log_alarm.ALARM_PRIORITY_VAL = Convert.ToByte(new Random().Next(1, 2));

                    log_info.DATA_80 = log_alarm.ALARM_CODE;
                    log_info.DATA_81 = log_alarm.ALARM_DATA_L;
                    log_info.DATA_82 = log_alarm.ALARM_DATA_H;
                    log_info.DATA_83 = log_alarm.ALARM_PRIORITY_VAL;
                }
                ///如果log类型是"非激活状态"
                else if (log_info.LOG_DEF_L + 256 * log_info.LOG_DEF_H == LOG_TYPE_NONE_ACTIVE)
                {

                    LOG_NOT_ACTIVE log_non_active = new LOG_NOT_ACTIVE();
                    log_non_active.NOT_ACTIVE_CODE = 1;

                    log_info.DATA_80 = log_non_active.NOT_ACTIVE_CODE;
                }
                ///如果log类型是"操作记录"
                else if (log_info.LOG_DEF_L + 256 * log_info.LOG_DEF_H == LOG_TYPE_OP_RECORD)
                {
                    LOG_OP_RECORD log_OP_record = new LOG_OP_RECORD();
                    log_OP_record.OP_CODE = Convert.ToByte(new Random().Next(1, 3));
                    log_OP_record.CHANGE_CODE = Convert.ToByte(new Random().Next(1, 7));
                    log_OP_record.OP_CHANGE_BEFORE_VAL= Convert.ToByte(new Random().Next(1, 9));
                    log_OP_record.OP_CHANGE_AFTER_VAL = Convert.ToByte(new Random().Next(1, 9));
                    log_OP_record.MODE_AND_TIME = Convert.ToByte(new Random().Next(1, 9));
                    log_OP_record.SET_TEMPERATURE = Convert.ToByte(new Random().Next(31, 37));
                    log_OP_record.SET_FLOW = Convert.ToByte(new Random().Next(2, 80));
                    log_OP_record.SET_HIGH_O2CON_ALARM = Convert.ToByte(new Random().Next(26, 95));
                    log_OP_record.SET_LOW_O2CON_ALARM = Convert.ToByte(new Random().Next(18, 91));
                    log_OP_record.SET_ADULT_OR_BABY = Convert.ToByte(new Random().Next(0, 1));
                    log_OP_record.BLENDER_A_M = Convert.ToByte(new Random().Next(1, 2));
                    log_OP_record.SET_O2_CON = Convert.ToByte(new Random().Next(21, 95));

                    log_info.DATA_80 = log_OP_record.OP_CODE;
                    log_info.DATA_81 = log_OP_record.CHANGE_CODE;
                    log_info.DATA_82 = log_OP_record.OP_CHANGE_BEFORE_VAL;
                    log_info.DATA_83 = log_OP_record.OP_CHANGE_AFTER_VAL;
                    log_info.DATA_84 = log_OP_record.MODE_AND_TIME;
                    log_info.DATA_85 = log_OP_record.SET_TEMPERATURE;
                    log_info.DATA_86 = log_OP_record.SET_FLOW;
                    log_info.DATA_87 = log_OP_record.SET_HIGH_O2CON_ALARM;
                    log_info.DATA_88 = log_OP_record.SET_LOW_O2CON_ALARM;
                    log_info.DATA_89 = log_OP_record.SET_ADULT_OR_BABY;
                    log_info.DATA_90 = log_OP_record.BLENDER_A_M;
                    log_info.DATA_91 = log_OP_record.SET_O2_CON;
                }
                ///如果log类型是"pre-use check"
                else if (log_info.LOG_DEF_L + 256 * log_info.LOG_DEF_H == LOG_TYPE_PRE_USE_CHECK)
                {
                    LOG_PRE_USE_CHECK log_preUse_check = new LOG_PRE_USE_CHECK();
                    log_preUse_check.check_result = 1;
                    int circle_type = (new Random()).Next(21, 31);
                    log_preUse_check._6Pin_circle_type_L = Convert.ToByte(circle_type % 256);
                    log_preUse_check._6Pin_circle_type_H = Convert.ToByte(circle_type / 256);
                    log_preUse_check.temp_patient = Convert.ToByte(rnd_val.Next(20, 90));
                    log_preUse_check.temp_outlet = Convert.ToByte(rnd_val.Next(20, 90));
                    log_preUse_check.temp_ambient = Convert.ToByte(rnd_val.Next(20, 90));
                    log_preUse_check.circle_resitor_val = Convert.ToByte(rnd_val.Next(100, 255));
                    log_preUse_check.WATER_LEVEL_SENSOR_HADC_L = 0;
                    log_preUse_check.WATER_LEVEL_SENSOR_HADC_H = 0;
                    log_preUse_check.WATER_LEVEL_SENSOR_LADC_L = 0;
                    log_preUse_check.WATER_LEVEL_SENSOR_LADC_H = 0;
                    log_preUse_check.LEAK_CHECK_VAL = Convert.ToByte(rnd_val.Next(1, 3));

                    log_info.DATA_80 = log_preUse_check.check_result;
                    log_info.DATA_81 = log_preUse_check._6Pin_circle_type_L;
                    log_info.DATA_82 = log_preUse_check._6Pin_circle_type_H;
                    log_info.DATA_83 = log_preUse_check.temp_patient;
                    log_info.DATA_84 = log_preUse_check.temp_outlet;
                    log_info.DATA_85 = log_preUse_check.temp_ambient;
                    log_info.DATA_86 = log_preUse_check.circle_resitor_val;
                    log_info.DATA_87 = log_preUse_check.WATER_LEVEL_SENSOR_HADC_L;
                    log_info.DATA_88 = log_preUse_check.WATER_LEVEL_SENSOR_HADC_H;
                    log_info.DATA_89 = log_preUse_check.WATER_LEVEL_SENSOR_LADC_L;
                    log_info.DATA_90 = log_preUse_check.WATER_LEVEL_SENSOR_LADC_H;
                    log_info.DATA_91 = log_preUse_check.LEAK_CHECK_VAL;
                }
                ///如果log类型是"切换供电电源"
                else if (log_info.LOG_DEF_L + 256 * log_info.LOG_DEF_H == LOG_TYPE_24_SWITCH)
                {
                    LOG_24V_STATE log_24V_state = new LOG_24V_STATE();
                    log_24V_state.code = 1;
                    log_24V_state.change_before_val = Convert.ToByte(new Random().Next(1, 2));
                    log_24V_state.change_after_val = Convert.ToByte(new Random().Next(1, 2));

                    log_info.DATA_80 = log_24V_state.code;
                    log_info.DATA_81 = log_24V_state.change_before_val;
                    log_info.DATA_82 = log_24V_state.change_after_val;
                }

                Byte[] log_array = StructToBytes(log_info);
                bw.Write(log_array, 0, 128);
            }

            bw.Close();
            fs.Close();
        }

        public static Byte[] StructToBytes(Object structure)
        {
            Int32 size = Marshal.SizeOf(structure);
            IntPtr buffer = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(structure, buffer, false);
                Byte[] bytes = new Byte[size];
                Marshal.Copy(buffer, bytes, 0, size);

                return bytes;
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }

        }
        public static T GetObject<T>(byte[] data, int size)
        {
            Contract.Assume(size == Marshal.SizeOf(typeof(T)));
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.Copy(data, 0, ptr, size);
                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
        //public static byte[] StructToBytes(object structObj)
        //{
        //    //得到结构体的大小
        //    int size = Marshal.SizeOf(structObj);
        //    //创建byte数组
        //    byte[] _bytes = new byte[size];
        //    //分配结构体大小的内存空间
        //    IntPtr structPtr = Marshal.AllocHGlobal(size);
        //    //将结构体拷到分配好的内存空间
        //    Marshal.StructureToPtr(structObj, structPtr, false);
        //    //从内存空间拷到byte数组
        //    Marshal.Copy(structPtr, _bytes, 0, size);
        //    //释放内存空间
        //    Marshal.FreeHGlobal(structPtr);
        //    //返回byte数组
        //    return _bytes;
        //}
        private byte generate_mode_and_time(int random_val)
        {
            byte ret = 0;
            if (random_val == 1)
            {
                byte bt = 0x01;
                Random rnd = new Random();
                byte val = Convert.ToByte(rnd.Next(5, 30));
                val = Convert.ToByte(val << 3);  //左移3位
                val |= bt;

                ret = val;
            }
            else if (random_val == 0)
            {
                //do nothing
            }
            return ret;
        }

        private void update_UI_by_language()
        {
            if (LanguageMngr.m_lang == LanguageMngr.LANGUAGE.CHINESE)
            {
                setToolStripMenuItem.Text = "设置";
                languageToolStripMenuItem.Text = "语言";
                importDataToolStripMenuItem.Text = "导入数据";
                chineseToolStripMenuItem.Text = "中文";
                englishToolStripMenuItem.Text = "英文";
                aboutToolStripMenuItem.Text = "关于";
                button_top_page.Text = "首页";
                button_end_page.Text = "尾页";
                button_pre_page.Text = "上一页";
                button_next_page.Text = "下一页";
                label_listview_jumpto.Text = "跳转到:";
                groupBox_equipInfo.Text = "设备信息";
                label_equipType.Text = "型号:";
                label_softwarVer.Text = "软件版本:";
            }
            else if (LanguageMngr.m_lang == LanguageMngr.LANGUAGE.ENGLISH)
            {
                setToolStripMenuItem.Text = "Set";
                languageToolStripMenuItem.Text = "Language";
                importDataToolStripMenuItem.Text = "ImportData";
                chineseToolStripMenuItem.Text = "Chinese";
                englishToolStripMenuItem.Text = "English";
                aboutToolStripMenuItem.Text = "About";
                button_top_page.Text = "Top Page";
                button_end_page.Text = "End Page";
                button_pre_page.Text = "Pre Page";
                button_next_page.Text = "Next Page";
                label_listview_jumpto.Text = "Jump To:";
                groupBox_equipInfo.Text = "Equipment Info";
                label_equipType.Text = "Model:";
                label_softwarVer.Text = "Software Ver:";
            }

            Init_listView_log();
            update_listView();
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageMngr.m_lang = LanguageMngr.LANGUAGE.CHINESE;
            update_UI_by_language();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageMngr.m_lang = LanguageMngr.LANGUAGE.ENGLISH;
            update_UI_by_language();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string strPath = folderBrowserDialog1.SelectedPath;
                //判断打开的文件夹是否有效
                int file_cnt = check_loggingFile_cnt(strPath);
                if (file_cnt == 0)
                {
                    MessageBox.Show(LanguageMngr.pls_choose_the_right_folder());
                }
                else if (file_cnt == 1)
                {
                    //do nothing
                    //MessageBox.Show("ok");
                    m_list_logInfo.Clear();  //先清除，在使用
                    m_total_page = 0;
                    m_curr_page = 0;
                    m_start_index = 0;
                    m_end_index = 0;
                    textBox_jumpto.Text = "";

                    //解析数据到链表
                    get_data_2_list(strPath);

                    //更新"页管理"数据
                    if (m_list_logInfo.Count() > 0)
                    {
                        //获取一共有多少页
                        m_total_page = (m_list_logInfo.Count() % m_PAGE_SIZE > 0) ? (m_list_logInfo.Count() / m_PAGE_SIZE + 1) : m_list_logInfo.Count() / m_PAGE_SIZE;
                        //当前页
                        m_curr_page = 1;
                    }

                    //更新listView
                    update_listView();
                }
            }
        }

        private void update_listView()
        {
            refresh_listView_page_ctrl();

            if (m_list_logInfo.Count() > 0)
            {
                this.listView_log.Items.Clear();
                for (int i = m_start_index; i < m_end_index; i++)
                {
                    this.listView_log.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (i + 1).ToString();
                    //Log类型
                    int log_type = m_list_logInfo[i].LOG_DEF_L + m_list_logInfo[i].LOG_DEF_H * 256;

                    string str_logType = "";
                    if (log_type == LOG_TYPE_ALARM)
                    {
                        str_logType = LanguageMngr.log_type_alarm();
                    }
                    else if (log_type == LOG_TYPE_NONE_ACTIVE)
                    {
                        str_logType = LanguageMngr.log_type_non_active();
                    }
                    else if (log_type == LOG_TYPE_OP_RECORD)
                    {
                        str_logType = LanguageMngr.log_type_OP_record();
                    }
                    else if (log_type == LOG_TYPE_PRE_USE_CHECK)
                    {
                        str_logType = LanguageMngr.log_type_pre_use_check();
                    }
                    else if (log_type == LOG_TYPE_24_SWITCH)
                    {
                        str_logType = LanguageMngr.log_type_24V_switch();
                    }

                    lvi.SubItems.Add(str_logType);

                    //log 开始时间
                    int start_year = m_list_logInfo[i].START_YEAR_L + m_list_logInfo[i].START_YEAR_H * 256;
                    int start_month = m_list_logInfo[i].START_MONTH;
                    int start_day = m_list_logInfo[i].START_DAY;
                    int start_hour = m_list_logInfo[i].START_HOUR;
                    int start_min = m_list_logInfo[i].START_MIN;
                    int start_second = m_list_logInfo[i].START_SECOND;
                    string srt_startTime = start_year.ToString() + @"/" + start_month.ToString().PadLeft(2, '0') + @"/" + start_day.ToString().PadLeft(2, '0') + @" "
                                        + start_hour.ToString().PadLeft(2, '0') + @":" + start_min.ToString().PadLeft(2, '0') + @":" + start_second.ToString().PadLeft(2, '0');
                    lvi.SubItems.Add(srt_startTime);
                    //log 结束时间
                    int end_year = m_list_logInfo[i].END_YEAR_L + m_list_logInfo[i].END_YEAR_H * 256;
                    int end_month = m_list_logInfo[i].END_MONTH;
                    int end_day = m_list_logInfo[i].END_DAY;
                    int end_hour = m_list_logInfo[i].END_HOUR;
                    int end_min = m_list_logInfo[i].END_MIN;
                    int end_second = m_list_logInfo[i].END_SECOND;
                    string srt_endTime = end_year.ToString() + @"/" + end_month.ToString().PadLeft(2, '0') + @"/" + end_day.ToString().PadLeft(2, '0') + @" "
                                        + end_hour.ToString().PadLeft(2, '0') + @":" + end_min.ToString().PadLeft(2, '0') + @":" + end_second.ToString().PadLeft(2, '0');
                    lvi.SubItems.Add(srt_endTime);
                    //log record
                    //根据log类型来
                    string str_log_info = "";
                    if (log_type == LOG_TYPE_ALARM)
                    {
                        LOG_ALARM log_alarm = new LOG_ALARM();

                        log_alarm.ALARM_CODE = m_list_logInfo[i].DATA_80;
                        log_alarm.ALARM_DATA_L = m_list_logInfo[i].DATA_81;
                        log_alarm.ALARM_DATA_H = m_list_logInfo[i].DATA_82;
                        log_alarm.ALARM_PRIORITY_VAL = m_list_logInfo[i].DATA_83;

                        //优先级
                        if (log_alarm.ALARM_PRIORITY_VAL == ALARM_PRIORITY_MEDIUM)      //中优先级
                        {
                            str_log_info += LanguageMngr.medium_priority_alarm();
                        }
                        else if (log_alarm.ALARM_PRIORITY_VAL == ALARM_PRIORITY_HIGH)   //高优先级
                        {
                            str_log_info += LanguageMngr.high_priority_alarm();
                        }
                        str_log_info += ",";
                        str_log_info += get_detail_alarm_info(log_alarm.ALARM_CODE);

                        //TODO, 后续得加上数据ALARM_DATA_L和ALARM_DATA_H
                    }
                    else if (log_type == LOG_TYPE_NONE_ACTIVE)
                    {
                        LOG_NOT_ACTIVE log_non_active = new LOG_NOT_ACTIVE();

                        log_non_active.NOT_ACTIVE_CODE = m_list_logInfo[i].DATA_80;

                        str_log_info += LanguageMngr.alarm_sound_paused();
                    }
                    else if (log_type == LOG_TYPE_OP_RECORD)
                    {
                        LOG_OP_RECORD log_OP_record = new LOG_OP_RECORD();
                        log_OP_record.OP_CODE = m_list_logInfo[i].DATA_80;
                        log_OP_record.CHANGE_CODE = m_list_logInfo[i].DATA_81;
                        log_OP_record.OP_CHANGE_BEFORE_VAL = m_list_logInfo[i].DATA_82;
                        log_OP_record.OP_CHANGE_AFTER_VAL = m_list_logInfo[i].DATA_83;
                        log_OP_record.MODE_AND_TIME = m_list_logInfo[i].DATA_84;
                        log_OP_record.SET_TEMPERATURE = m_list_logInfo[i].DATA_85;
                        log_OP_record.SET_FLOW = m_list_logInfo[i].DATA_86;
                        log_OP_record.SET_HIGH_O2CON_ALARM = m_list_logInfo[i].DATA_87;
                        log_OP_record.SET_LOW_O2CON_ALARM = m_list_logInfo[i].DATA_88;
                        log_OP_record.SET_ADULT_OR_BABY = m_list_logInfo[i].DATA_89;
                        log_OP_record.BLENDER_A_M = m_list_logInfo[i].DATA_90;
                        log_OP_record.SET_O2_CON = m_list_logInfo[i].DATA_91;

                        //开机后的初始设置
                        if (log_OP_record.OP_CODE == OP_RECORD_OpCode_INIT_SET)
                        {
                            str_log_info += LanguageMngr.device_boot_up() + ",";
                            str_log_info += LanguageMngr.set_para() + ":";
                            //设置模式
                            if (log_OP_record.SET_ADULT_OR_BABY == MODE_BABY)
                            {
                                str_log_info += LanguageMngr.baby_mode() + ",";
                            }
                            else if (log_OP_record.SET_ADULT_OR_BABY == MODE_ADULT)
                            {
                                str_log_info += LanguageMngr.adult_mode() + ",";
                            }
                            //设置温度
                            str_log_info += log_OP_record.SET_TEMPERATURE.ToString() + "℃" + ",";
                            //设置流量
                            str_log_info += log_OP_record.SET_FLOW.ToString() + "L/min" + ",";
                            //设置高氧浓度报警限值
                            str_log_info += LanguageMngr.high_O2Con_alarm_limit() + "：" + log_OP_record.SET_HIGH_O2CON_ALARM.ToString() + "%,";
                            //设置低氧浓度报警限值
                            str_log_info += LanguageMngr.low_O2Con_alarm_limit() + "：" + log_OP_record.SET_LOW_O2CON_ALARM.ToString() + "%,";
                            //供电方式
                            str_log_info += LanguageMngr.power_source() + ":";
                            if (m_list_logInfo[i]._24V_SOURCE_FLG == LOG_INFO_24V_FROM_AC)
                            {
                                str_log_info += LanguageMngr.AC_source();
                            }
                            else if (m_list_logInfo[i]._24V_SOURCE_FLG == LOG_INFO_24V_FROM_BAT)
                            {
                                str_log_info += LanguageMngr.bat();
                            }
                            str_log_info += ",";
                            //空氧混合方式(A/M)
                            str_log_info += LanguageMngr.blender_mode() + ":";
                            if (log_OP_record.BLENDER_A_M == OP_RECORD_BLENDER_M_EXIST)
                            {
                                str_log_info += LanguageMngr.manual();
                            }
                            else if (log_OP_record.BLENDER_A_M == OP_RECORD_BLENDER_A_EXIST)
                            {
                                str_log_info += LanguageMngr.auto();
                            }
                            str_log_info += ",";
                            //设置氧浓度
                            str_log_info += LanguageMngr.set_O2Con() + ":";
                            str_log_info += log_OP_record.SET_O2_CON.ToString() + "%";
                        }
                        //报警设置改变
                        else if (log_OP_record.OP_CODE == OP_RECORD_OpCode_ALARM_SET_CHANGE)
                        {
                            str_log_info += LanguageMngr.alarm_set_changed() + ":";

                            if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_HighO2ConAlarm_SET)
                            {
                                str_log_info += LanguageMngr.high_O2Con_alarm_limit();
                                str_log_info += LanguageMngr.from();
                                str_log_info += log_OP_record.OP_CHANGE_BEFORE_VAL.ToString() + "%";
                                str_log_info += LanguageMngr.to();
                                str_log_info += log_OP_record.OP_CHANGE_AFTER_VAL.ToString() + "%";
                            }
                            else if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_LowO2ConAlarm_SET)
                            {
                                str_log_info += LanguageMngr.low_O2Con_alarm_limit();
                                str_log_info += LanguageMngr.from();
                                str_log_info += log_OP_record.OP_CHANGE_BEFORE_VAL.ToString() + "%";
                                str_log_info += LanguageMngr.to();
                                str_log_info += log_OP_record.OP_CHANGE_AFTER_VAL.ToString() + "%";
                            }
                            str_log_info += ",";

                            //运行状态
                            str_log_info += LanguageMngr.workstate() + ":";
                            str_log_info += get_work_state(m_list_logInfo[i]);
                        }
                        //治疗参数改变
                        else if (log_OP_record.OP_CODE == OP_RECORD_OpCode_SET_PARA_CHANGE)
                        {
                            str_log_info += LanguageMngr.treatment_para_changed() + ":";
                            //成人/儿童模式被改变
                            if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_ADULT_BABY_MODE)
                            {
                                //改前
                                if (log_OP_record.OP_CHANGE_BEFORE_VAL == MODE_ADULT)
                                {
                                    str_log_info += LanguageMngr.adult_mode();
                                    str_log_info += LanguageMngr.change_to();
                                }
                                else if (log_OP_record.OP_CHANGE_BEFORE_VAL == MODE_ADULT)
                                {
                                    str_log_info += LanguageMngr.baby_mode();
                                    str_log_info += LanguageMngr.change_to();
                                }
                                //改后
                                if (log_OP_record.OP_CHANGE_AFTER_VAL == MODE_ADULT)
                                {
                                    str_log_info += LanguageMngr.adult_mode();
                                }
                                else if (log_OP_record.OP_CHANGE_AFTER_VAL == MODE_ADULT)
                                {
                                    str_log_info += LanguageMngr.baby_mode();
                                }
                                str_log_info += ",";

                                //运行状态
                                str_log_info += LanguageMngr.workstate() + ":";
                                str_log_info += get_work_state(m_list_logInfo[i]);
                            }
                            //温度设置被改变
                            else if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_TEMP_SET)
                            {
                                str_log_info += LanguageMngr.treatment_para_changed() + ":";
                                str_log_info += LanguageMngr.temperature() + " ";

                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_BEFORE_VAL.ToString() + "℃";
                                str_log_info += LanguageMngr.change_to();
                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_AFTER_VAL.ToString() + "℃";

                                str_log_info += ",";
                                //运行状态
                                str_log_info += LanguageMngr.workstate() + ":";
                                str_log_info += get_work_state(m_list_logInfo[i]);
                            }
                            //流量设置被改变
                            else if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_FLOW_SET)
                            {
                                str_log_info += LanguageMngr.treatment_para_changed() + ":";
                                str_log_info += LanguageMngr.flow() + " ";

                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_BEFORE_VAL.ToString() + "L/min";
                                str_log_info += LanguageMngr.change_to();
                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_AFTER_VAL.ToString() + "L/min";

                                str_log_info += ",";
                                //运行状态
                                str_log_info += LanguageMngr.workstate() + ":";
                                str_log_info += get_work_state(m_list_logInfo[i]);
                            }
                            //氧浓度设置被改变
                            else if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_O2Con_SET)
                            {
                                str_log_info += LanguageMngr.treatment_para_changed() + ":";
                                str_log_info += LanguageMngr.O2Con() + " ";

                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_BEFORE_VAL.ToString() + "%";
                                str_log_info += LanguageMngr.change_to();
                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_AFTER_VAL.ToString() + "%";

                                str_log_info += ",";
                                //运行状态
                                str_log_info += LanguageMngr.workstate() + ":";
                                str_log_info += get_work_state(m_list_logInfo[i]);
                            }
                            //治疗模式被改变(work state被改变)
                            else if (log_OP_record.CHANGE_CODE == OP_RECORD_OPChangeCode_TREAATMENT_MODE_CHANGE)
                            {
                                str_log_info += LanguageMngr.treatment_para_changed() + ":";

                                //运行状态
                                str_log_info += LanguageMngr.workstate() + ":";
                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_BEFORE_VAL.ToString();
                                str_log_info += LanguageMngr.change_to();
                                str_log_info += LanguageMngr.from() + log_OP_record.OP_CHANGE_AFTER_VAL.ToString();

                                //if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_POWER_OFF)
                                //{

                                //}
                                //else if(log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_SELFCHECK)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_PREUSE_CHECK)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_PAUSE)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_RUN)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_TARNSPORT_MODE)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_COOLING_DOWN_MODE)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_LOWFLOW_MODE_PAUSE)
                                //{

                                //}
                                //else if (log_OP_record.OP_CHANGE_BEFORE_VAL == OP_WorkState_LOWFLOW_MODE_RUN)
                                //{

                                //}
                            }
                        }

                    }
                    else if (log_type == LOG_TYPE_PRE_USE_CHECK)
                    {
                        LOG_PRE_USE_CHECK log_pre_use_check = new LOG_PRE_USE_CHECK();

                        log_pre_use_check.check_result = m_list_logInfo[i].DATA_80;
                        log_pre_use_check._6Pin_circle_type_L = m_list_logInfo[i].DATA_81;
                        log_pre_use_check._6Pin_circle_type_H = m_list_logInfo[i].DATA_82;
                        log_pre_use_check.temp_patient = m_list_logInfo[i].DATA_83;
                        log_pre_use_check.temp_outlet = m_list_logInfo[i].DATA_84;
                        log_pre_use_check.temp_ambient = m_list_logInfo[i].DATA_85;
                        log_pre_use_check.circle_resitor_val = m_list_logInfo[i].DATA_86;
                        log_pre_use_check.WATER_LEVEL_SENSOR_HADC_L = m_list_logInfo[i].DATA_87;
                        log_pre_use_check.WATER_LEVEL_SENSOR_HADC_H = m_list_logInfo[i].DATA_88;
                        log_pre_use_check.WATER_LEVEL_SENSOR_LADC_L = m_list_logInfo[i].DATA_89;
                        log_pre_use_check.WATER_LEVEL_SENSOR_LADC_H = m_list_logInfo[i].DATA_90;
                        log_pre_use_check.LEAK_CHECK_VAL = m_list_logInfo[i].DATA_91;

                        //pre-use 检测结果
                        if (log_pre_use_check.check_result == PRE_USE_CHECK_PASS)
                        {
                            str_log_info += LanguageMngr.pre_use_check_pass();
                        }
                        else if (log_pre_use_check.check_result == PRE_USE_CHECK_FAIL)
                        {
                            str_log_info += LanguageMngr.pre_use_check_fail();
                        }
                        //回路类型
                        str_log_info += LanguageMngr._6Pin_circle_ID() + ":";
                        str_log_info += "0" + (log_pre_use_check._6Pin_circle_type_L + log_pre_use_check._6Pin_circle_type_H * 256).ToString() + ",";
                        //患者端温度
                        str_log_info += LanguageMngr.patient_temperature() + ":" + log_pre_use_check.temp_patient.ToString() + "℃" + ",";
                        //出气口温度
                        str_log_info += LanguageMngr.outlet_temperature() + ":" + log_pre_use_check.temp_outlet.ToString() + "℃" + ",";
                        //环境温度
                        str_log_info += LanguageMngr.ambient_temperature() + ":" + log_pre_use_check.temp_ambient.ToString() + "℃" + ",";
                        //回路电阻
                        str_log_info += LanguageMngr._6Pin_circle_resistor() + ":" + log_pre_use_check.circle_resitor_val.ToString() + "Ω" + ",";
                        //水罐安装检查
                        int humidifyingCan_ADC_val = log_pre_use_check.WATER_LEVEL_SENSOR_HADC_L + log_pre_use_check.WATER_LEVEL_SENSOR_HADC_H * 256;
                        str_log_info += LanguageMngr.alarm_code_check_chamber() + ":";
                        if (humidifyingCan_ADC_val > 2000)
                        {
                            str_log_info += LanguageMngr.OK();
                        }
                        else
                        {
                            str_log_info += LanguageMngr.NG();
                        }
                        str_log_info += ",";
                        //水位检查
                        int water_level_ADC_val = log_pre_use_check.WATER_LEVEL_SENSOR_LADC_L + log_pre_use_check.WATER_LEVEL_SENSOR_LADC_H * 256;
                        str_log_info += LanguageMngr.water_level_check() + ":";
                        if (water_level_ADC_val > 1200)
                        {
                            str_log_info += LanguageMngr.OK();
                        }
                        else
                        {
                            str_log_info += LanguageMngr.NG();
                        }
                        str_log_info += ",";
                        //泄露检查
                        str_log_info += LanguageMngr.leak_check() + ":";
                        if (log_pre_use_check.LEAK_CHECK_VAL < 3)
                        {
                            str_log_info += LanguageMngr.OK();
                        }
                        else
                        {
                            str_log_info += LanguageMngr.NG();
                        }
                    }
                    else if (log_type == LOG_TYPE_24_SWITCH)
                    {
                        LOG_24V_STATE log_24V_state = new LOG_24V_STATE();

                        log_24V_state.code = m_list_logInfo[i].DATA_80;
                        log_24V_state.change_before_val = m_list_logInfo[i].DATA_81;
                        log_24V_state.change_after_val = m_list_logInfo[i].DATA_82;

                        if (log_24V_state.code == _24V_CODE_SOURCE_CHANGED)
                        {
                            str_log_info += LanguageMngr.power_source_switched();
                            //改变前
                            string change_before = "";
                            if (log_24V_state.change_before_val == _24V_FORM_AC)
                            {
                                change_before = LanguageMngr.AC_source();
                            }
                            else if (log_24V_state.change_before_val == _24V_FROM_BAT)
                            {
                                change_before = LanguageMngr.bat();
                            }

                            str_log_info += change_before + "->";
                            //改变后
                            string change_after = "";
                            if (log_24V_state.change_after_val == _24V_FORM_AC)
                            {
                                change_after = LanguageMngr.AC_source();
                            }
                            else if (log_24V_state.change_after_val == _24V_FROM_BAT)
                            {
                                change_after = LanguageMngr.bat();
                            }
                            str_log_info += change_after;
                        }

                    }
                    lvi.SubItems.Add(str_log_info);
                    this.listView_log.Items.Add(lvi);
                    this.listView_log.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
                }
            }
        }

        private string get_work_state(LOG_INFO log_info )
        {
            string str_log_info = "";
            if (log_info.WORK_STATE == OP_WorkState_POWER_OFF)
            {
                str_log_info += LanguageMngr.power_off();
            }
            else if (log_info.WORK_STATE == OP_WorkState_SELFCHECK)
            {
                str_log_info += LanguageMngr.selfcheck();
            }
            else if (log_info.WORK_STATE == OP_WorkState_PREUSE_CHECK)
            {
                str_log_info += LanguageMngr.pre_use_check();
            }
            else if (log_info.WORK_STATE == OP_WorkState_PAUSE)
            {
                str_log_info += LanguageMngr.pause();
            }
            else if (log_info.WORK_STATE == OP_WorkState_RUN)
            {
                str_log_info += LanguageMngr.run();
            }
            else if (log_info.WORK_STATE == OP_WorkState_TARNSPORT_MODE)
            {
                str_log_info += LanguageMngr.transmode();
            }
            else if (log_info.WORK_STATE == OP_WorkState_COOLING_DOWN_MODE)
            {
                str_log_info += LanguageMngr.cooling_down_mode();
            }
            else if (log_info.WORK_STATE == OP_WorkState_LOWFLOW_MODE_PAUSE)
            {
                str_log_info += LanguageMngr.low_flow_mode_pause();
            }
            else if (log_info.WORK_STATE == OP_WorkState_LOWFLOW_MODE_RUN)
            {
                str_log_info += LanguageMngr.low_flow_mode_run();
            }
            return str_log_info;
        }

        private string get_detail_alarm_info(byte ALARM_CODE)
        {
            string ret = "";
            if(ALARM_CODE== ALARM_CODE_E1)
            {
                ret += LanguageMngr.alarm_code_E1();
            }
            else if (ALARM_CODE == ALARM_CODE_E2)
            {
                ret += LanguageMngr.alarm_code_E2();
            }
            else if (ALARM_CODE == ALARM_CODE_E3)
            {
                ret += LanguageMngr.alarm_code_E3();
            }
            else if (ALARM_CODE == ALARM_CODE_E4)
            {
                ret += LanguageMngr.alarm_code_E4();
            }
            else if (ALARM_CODE == ALARM_CODE_E5)
            {
                ret += LanguageMngr.alarm_code_E5();
            }
            else if (ALARM_CODE == ALARM_CODE_E6)
            {
                ret += LanguageMngr.alarm_code_E6();
            }
            else if (ALARM_CODE == ALARM_CODE_E7)
            {
                ret += LanguageMngr.alarm_code_E7();
            }
            else if (ALARM_CODE == ALARM_CODE_E8)
            {
                ret += LanguageMngr.alarm_code_E8();
            }
            else if (ALARM_CODE == ALARM_CODE_E9)
            {
                ret += LanguageMngr.alarm_code_E9();
            }
            else if (ALARM_CODE == ALARM_CODE_E10)
            {
                ret += LanguageMngr.alarm_code_E10();
            }
            else if (ALARM_CODE == ALARM_CODE_E11)
            {
                ret += LanguageMngr.alarm_code_E11();
            }
            else if (ALARM_CODE == ALARM_CODE_E12)
            {
                ret += LanguageMngr.alarm_code_E12();
            }
            else if (ALARM_CODE == ALARM_CODE_E13)
            {
                ret += LanguageMngr.alarm_code_E13();
            }
            else if (ALARM_CODE == ALARM_CODE_E14)
            {
                ret += LanguageMngr.alarm_code_E14();
            }
            else if (ALARM_CODE == ALARM_CODE_E15)
            {
                ret += LanguageMngr.alarm_code_E15();
            }
            else if (ALARM_CODE == ALARM_CODE_E16)
            {
                ret += LanguageMngr.alarm_code_E16();
            }
            else if (ALARM_CODE == ALARM_CODE_E17)
            {
                ret += LanguageMngr.alarm_code_E17();
            }
            else if (ALARM_CODE == ALARM_CODE_E18)
            {
                ret += LanguageMngr.alarm_code_E18();
            }
            else if (ALARM_CODE == ALARM_CODE_E19)
            {
                ret += LanguageMngr.alarm_code_E19();
            }
            else if (ALARM_CODE == ALARM_CODE_E20)
            {
                ret += LanguageMngr.alarm_code_E20();
            }
            else if (ALARM_CODE == ALARM_CODE_E21)
            {
                ret += LanguageMngr.alarm_code_E21();
            }
            else if (ALARM_CODE == ALARM_CODE_E22)
            {
                ret += LanguageMngr.alarm_code_E22();
            }
            else if (ALARM_CODE == ALARM_CODE_E23)
            {
                ret += LanguageMngr.alarm_code_E23();
            }
            else if (ALARM_CODE == ALARM_CODE_E24)
            {
                ret += LanguageMngr.alarm_code_E24();
            }
            else if (ALARM_CODE == ALARM_CODE_E25)
            {
                ret += LanguageMngr.alarm_code_E25();
            }
            else if (ALARM_CODE == ALARM_CODE_E26)
            {
                ret += LanguageMngr.alarm_code_E26();
            }
            else if (ALARM_CODE == ALARM_CODE_E27)
            {
                ret += LanguageMngr.alarm_code_E27();
            }
            else if (ALARM_CODE == ALARM_CODE_E28)
            {
                ret += LanguageMngr.alarm_code_E28();
            }
            else if (ALARM_CODE == ALARM_CODE_E29)
            {
                ret += LanguageMngr.alarm_code_E29();
            }
            else if (ALARM_CODE == ALARM_CODE_E30)
            {
                ret += LanguageMngr.alarm_code_E30();
            }
            else if (ALARM_CODE == ALARM_CODE_E31)
            {
                ret += LanguageMngr.alarm_code_E31();
            }
            else if (ALARM_CODE == ALARM_CODE_E32)
            {
                ret += LanguageMngr.alarm_code_E32();
            }
            else if (ALARM_CODE == ALARM_CODE_HIGH_TEMPERATURE)
            {
                ret += LanguageMngr.alarm_code_high_temperatur();
            }
            else if (ALARM_CODE == ALARM_CODE_POWER_OFF)
            {
                ret += LanguageMngr.alarm_code_power_off();
            }
            else if (ALARM_CODE == ALARM_CODE_CHECK_CHAMBER)
            {
                ret += LanguageMngr.alarm_code_check_chamber();
            }
            else if (ALARM_CODE == ALARM_CODE_LACK_OF_WATER)
            {
                ret += LanguageMngr.alarm_code_lack_of_water();
            }
            else if (ALARM_CODE == ALARM_CODE_TEMP_PROBE_UNINSTALLED)
            {
                ret += LanguageMngr.alarm_code_temp_probe_not_install();
            }
            else if (ALARM_CODE == ALARM_CODE_TUBE_UNINSTALLED)
            {
                ret += LanguageMngr.alarm_code_tube_not_install();
            }
            else if (ALARM_CODE == ALARM_CODE_TUBE_NOT_MATCH)
            {
                ret += LanguageMngr.alarm_code_tube_not_match();
            }
            else if (ALARM_CODE == ALARM_CODE_CHECK_BLOCKAGES)
            {
                ret += LanguageMngr.alarm_code_check_blockages();
            }
            else if (ALARM_CODE == ALARM_CODE_HIGH_O2CON)
            {
                ret += LanguageMngr.alarm_code_high_O2Con();
            }
            else if (ALARM_CODE == ALARM_CODE_LOW_O2CON)
            {
                ret += LanguageMngr.alarm_code_low_O2Con();
            }
            else if (ALARM_CODE == ALARM_CODE_FLOW_OVERRANGE)
            {
                ret += LanguageMngr.alarm_code_flow_overrange();
            }
            else if (ALARM_CODE == ALARM_CODE_TEMP_OVERRANGE)
            {
                ret += LanguageMngr.alarm_code_temp_overrange();
            }
            else if (ALARM_CODE == ALAMR_CODE_TEMP_RPROBE_OUT)
            {
                ret += LanguageMngr.alarm_code_prob_out();
            }
            else if (ALARM_CODE == ALARM_CODE_SD_UNINSTALLED)
            {
                ret += LanguageMngr.alarm_code_sdCard_not_install();
            }
            else if (ALARM_CODE == ALARM_CODE_CIRCUIT_FAILURE_DATA_CABLE_UNINSTALLED)
            {
                ret += LanguageMngr.alarm_code_circuit_failure_data_cable_uninstalled();
            }
            else if (ALARM_CODE == ALARM_CODE_CHECK_LEAK)
            {
                ret += LanguageMngr.alarm_code_check_for_leaks();
            }
            else if (ALARM_CODE == ALARM_CODE_LOW_BAT_CAPACITY)
            {
                ret += LanguageMngr.alarm_code_low_bat_cap();
            }
            else if (ALARM_CODE == ALARM_CODE_CANT_REACH_TARGET_O2CON)
            {
                ret += LanguageMngr.alarm_code_cant_reach_target_O2Con();
            }

            return ret;
        }

        private void get_data_2_list(string path)
        {
            string strFilePath = path + @"\Logging.vmf";
            FileStream fs = new FileStream(strFilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs, Encoding.ASCII);

            //0.文件识别码
            byte[] file_mark = br.ReadBytes(128);
            if (file_mark[1] == Convert.ToByte('L')
                && file_mark[2] == Convert.ToByte('O')
                && file_mark[3] == Convert.ToByte('G')
                && file_mark[4] == Convert.ToByte('G')
                && file_mark[5] == Convert.ToByte('I')
                && file_mark[6] == Convert.ToByte('N')
                && file_mark[7] == Convert.ToByte('G')
                )
            {
                //do nothing
            }
            else
            {
                MessageBox.Show(LanguageMngr.it_is_not_logging_file());
                br.Close();
                fs.Close();
                return;
            }

            //1.机型号
            byte[] machine_type = br.ReadBytes(128);
            string str_machineType = "";
            for (int i = 1; i <= machine_type[0]; i++)
            {
                str_machineType += (char)machine_type[i];
            }
            label_equipType_Value.Text = str_machineType;

            //2.SN
            byte[] SN = br.ReadBytes(128);
            string str_SN = "";
            for (int i = 1; i <= SN[0]; i++)
            {
                str_SN += (char)SN[i];
            }
            label_SN_Value.Text = str_SN;

            //3.软件版本
            byte[] software_ver = br.ReadBytes(128);
            string str_softwareVer = "";
            for (int i = 1; i <= software_ver[0]; i++)
            {
                str_softwareVer += software_ver[i].ToString();
                if (i != software_ver[0])
                {
                    str_softwareVer += ".";
                }
            }
            label_softwarVer_Value.Text = str_softwareVer;

            //4.Log文件版本号
            byte[] log_ver = br.ReadBytes(128);
            string str_logVer = "";
            for (int i = 1; i <= log_ver[0]; i++)
            {
                str_logVer += log_ver[i].ToString();
                if (i != log_ver[0])
                {
                    str_logVer += ".";
                }
            }

            //5-14,保留,没有使用
            for (int i = 5; i <= 14; i++)
            {
                br.ReadBytes(128);
            }

            //15.logging信息条数(这个没什么用)
            br.ReadBytes(128);

            //16-n
            while (true)    //读取log_info
            {
                byte[] buffer_msg = new byte[128];
                if (br.Read(buffer_msg, 0, 128) > 0)
                {
                    LOG_INFO logInfo=GetObject<LOG_INFO>(buffer_msg, 128);
                    m_list_logInfo.Add(logInfo);
                }
                else
                {
                    break;
                }
            }


            br.Close();
            fs.Close();
        }

        public int check_loggingFile_cnt(string strPath)
        {
            var loggingFilePath = Directory.GetFiles(strPath, "LOGGING.vmf"); //获取"Logging.vmf"文件的路径名
     
            return loggingFilePath.Length;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream(m_cfg_file_path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.ASCII);

            bw.Write((byte)LanguageMngr.m_lang);

            bw.Close();
            fs.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About about = new Form_About();

            about.set_version_label(LanguageMngr.software_ver() + SW_VERSION);
            about.ShowDialog();
        }

        private void button_top_page_Click(object sender, EventArgs e)
        {
            m_curr_page = 1;
            update_listView();
        }

        private void button_end_page_Click(object sender, EventArgs e)
        {
            m_curr_page = m_total_page;
            update_listView();
        }
        

        private void button_pre_page_Click(object sender, EventArgs e)
        {
            m_curr_page -= 1;
            if (m_curr_page < 1)
            {
                m_curr_page = 1;
            }
            update_listView();
        }

        private void refresh_listView_page_ctrl()
        {
            if (m_list_logInfo.Count() > 0)
            {
                m_start_index = (m_curr_page - 1) * m_PAGE_SIZE;
                m_end_index = m_curr_page * m_PAGE_SIZE;
                if (m_end_index > m_list_logInfo.Count())
                {
                    m_end_index = m_list_logInfo.Count();
                }

                textBox_listview_currentpage.Text = m_curr_page.ToString() + @"/" + m_total_page.ToString();
            }
        }

        private void button_next_page_Click(object sender, EventArgs e)
        {
            m_curr_page += 1;
            if (m_curr_page > m_total_page)
            {
                m_curr_page = m_total_page;
            }
            update_listView();
        }

        private void textBox_jumpto_TextChanged(object sender, EventArgs e)
        {
            var str = textBox_jumpto.Text;
            if (str.Length >= 10)
            {
                return;
            }
            if (str == "")
            {
                return;
            }
            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (ch < '0' || ch > '9')
                {
                    return;
                }
            }

            m_curr_page = Convert.ToInt32(textBox_jumpto.Text);
            if (m_curr_page >= 1 && m_curr_page <= m_total_page)
            {
                update_listView();
            }
        }
    }
}
