using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogReader
{
    class LanguageMngr
    {
        public enum LANGUAGE
        {
            CHINESE,
            ENGLISH
        }
        public static LANGUAGE m_lang= LANGUAGE.ENGLISH;

        public LanguageMngr()
        {

        }

        //public string set()
        //{
        //    string str = "";
        //    if (m_lang == LANGUAGE.CHINESE)
        //    {
        //        str = "设置";
        //    }
        //    else if (m_lang == LANGUAGE.ENGLISH)
        //    {
        //        str = "Set";
        //    }
        //    return str;
        //}
        
        public static string log_type()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "Log类型";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Log Type";
            }
            return str;
        }
        public static string start_time()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "开始时间";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Start Time";
            }
            return str;
        }
        public static string end_time()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "结束时间";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "End Time";
            }
            return str;
        }
        public static string Logging_record()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "记录内容";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Logging Record";
            }
            return str;
        }
        public static string log_type_alarm()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "报警记录";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "ALARM";
            }
            return str;
        }
        
        public static string log_type_non_active()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "非激活状态";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Non Active";
            }
            return str;
        }
        public static string log_type_OP_record()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "操作记录";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "OP record";
            }
            return str;
        }
        public static string log_type_pre_use_check()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "使用前检查";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Pre-use check";
            }
            return str;
        }
        public static string log_type_24V_switch()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "供电电源切换";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Power source switch";
            }
            return str;
        }

        public static string pls_choose_the_right_folder()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "请选择正确的文件夹。";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Please choose the right folder.";
            }
            return str;
        }

        public static string it_is_not_logging_file()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "该文件不是日志文件。";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "This file is not logging file";
            }
            return str;
        }
        
        public static string medium_priority_alarm()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "中优先级报警,";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Medium priority alarm,";
            }
            return str;
        }
        public static string high_priority_alarm()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "高优先级报警,";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "High priority alarm,";
            }
            return str;
        }
        public static string alarm_code_E1()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E1-氧浓度传感器故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E1-Oxygen concentration sensor error";
            }
            return str;
        }
        public static string alarm_code_E2()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E2-流量传感器故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E2-Flow sensor error";
            }
            return str;
        }
        public static string alarm_code_E3()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E3-压力传感器故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E3-Pressure sensor error";
            }
            return str;
        }
        public static string alarm_code_E4()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E4-加热盘温度传感器故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E4-Heating plate temperature sensor error";
            }
            return str;
        }
        public static string alarm_code_E5()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E5-散热风扇故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E5-Cooling fan error";
            }
            return str;
        }
        public static string alarm_code_E6()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E6-主风机过热故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E6-Blower overheating";
            }
            return str;
        }
        public static string alarm_code_E7()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E7-RTC故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E7-RTC error";
            }
            return str;
        }
        public static string alarm_code_E8()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E8-加热盘故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E8-Heating plate error";
            }
            return str;
        }
        public static string alarm_code_E9()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO)
                {
                    str = "系统故障E9-Memeory故障";
                }
                else if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E9-电池故障";
                }
                
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO)
                {
                    str = "System Error E9-Memeory error";
                }
                else if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E9-Battery error";
                }
                
            }
            return str;
        }

        public static string alarm_code_E10()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E10-和驱动板通信失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E10-Communicate with driver error";
                }
            }
            return str;
        }

        public static string alarm_code_E11()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E11-氧气混合模块故障";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E11-Blender error";
                }
            }
            return str;
        }
        public static string alarm_code_E12()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E12-主控板固件自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E12-MLB firmware error";
                }
            }
            return str;
        }
        public static string alarm_code_E13()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E13-驱动板固件自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E13-Driver firmware error";
                }
            }
            return str;
        }
        public static string alarm_code_E14()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E14-空氧混合板固件自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E14-Blender firmware error";
                }
            }
            return str;
        }
        public static string alarm_code_E15()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E15-主控板RAM自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E15-MLB RAM error";
                }
            }
            return str;
        }
        public static string alarm_code_E16()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E16-驱动板RAM自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E16-Driver RAM error";
                }
            }
            return str;
        }
        public static string alarm_code_E17()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E17-空氧混合板RAM自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E17-Blender RAM error";
                }
            }
            return str;
        }
        public static string alarm_code_E18()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E18-主控板FLASH自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E18-MLB flash error";
                }
            }
            return str;
        }
        public static string alarm_code_E19()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E19-驱动板FLASH自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E19-Driver flash error";
                }
            }
            return str;
        }
        public static string alarm_code_E20()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "系统故障E20-空氧混合板FLASH自检失败";
                }
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                if (Form1.DEVICE_ID == Form1.DEVICE_O2FLO_PRO)
                {
                    str = "System Error E20-Blender flash error";
                }
            }
            return str;
        }
        public static string alarm_code_E21()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E21-主控板5V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E21-MLB 5V error";
            }
            return str;
        }
        public static string alarm_code_E22()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E22-驱动板24V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E22-Driver 24V error";
            }
            return str;
        }
        public static string alarm_code_E23()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E23-驱动板12V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E23-Driver 12V error";
            }
            return str;
        }
        public static string alarm_code_E24()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E24-驱动板5V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E24-Driver 5V error";
            }
            return str;
        }
        public static string alarm_code_E25()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E25-空氧混合板12V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E25-Blender 12V error";
            }
            return str;
        }
        public static string alarm_code_E26()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E26-空氧混合板5V电压故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E26-Blender 5V error";
            }
            return str;
        }
        public static string alarm_code_E27()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E27-空氧混合板流量传感器故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E27-Blender flow sensor error";
            }
            return str;
        }
        public static string alarm_code_E28()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E28-空氧混合板比例阀故障";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E28-Blender valve error";
            }
            return str;
        }
        public static string alarm_code_E29()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E29-温控器开路";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E29-Temperatur controller error";
            }
            return str;
        }
        public static string alarm_code_E30()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E30-市电电压检测失败";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E30-AC check error";
            }
            return str;
        }
        public static string alarm_code_E31()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E31-主板散热风扇检测失败";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E31-MLB cooling fan error";
            }
            return str;
        }
        public static string alarm_code_E32()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "系统故障E32-blender NTC检测失败";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "System Error E32-Blender NTC check error";
            }
            return str;
        }
        public static string alarm_code_high_temperatur()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "超温";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "High temperature";
            }
            return str;
        }
        public static string alarm_code_power_off()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "电源断开";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Power off";
            }
            return str;
        }
        public static string alarm_code_check_chamber()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "检查水罐";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Check chamber";
            }
            return str;
        }
        public static string alarm_code_lack_of_water()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "缺水";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Lack of water";
            }
            return str;
        }
        public static string alarm_code_temp_probe_not_install()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "温度探头未安装";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Temp. probe not install";
            }
            return str;
        }
        public static string alarm_code_tube_not_install()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "管路未安装";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Tube uninstalled";
            }
            return str;
        }
        public static string alarm_code_tube_not_match()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "管路不匹配";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Tube not match";
            }
            return str;
        }
        public static string alarm_code_check_blockages()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "检查堵塞";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Check for blockages";
            }
            return str;
        }
        public static string alarm_code_high_O2Con()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "高氧浓度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Oxygen too high";
            }
            return str;
        }
        public static string alarm_code_low_O2Con()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "低氧浓度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Oxygen too low";
            }
            return str;
        }
        public static string alarm_code_flow_overrange()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "流量超范围";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Flow over range";
            }
            return str;
        }
        public static string alarm_code_temp_overrange()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "温度超范围";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Temp. Over range";
            }
            return str;
        }
        public static string alarm_code_prob_out()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "温度探头脱落";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Temp. Probe out";
            }
            return str;
        }
        public static string alarm_code_sdCard_not_install()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "SD卡未安装";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "SD Card Uninstalled";
            }
            return str;
        }
        public static string alarm_code_circuit_failure_data_cable_uninstalled()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "回路故障/温度探头未安装";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Circuit failure/data cable uninstalled";
            }
            return str;
        }
        public static string alarm_code_check_for_leaks()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "泄露";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Check for leaks";
            }
            return str;
        }
        public static string alarm_code_low_bat_cap()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "低电池电量";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Low bat capacity";
            }
            return str;
        }
        public static string alarm_code_cant_reach_target_O2Con()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "达不到设定氧浓度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Can't reach target O2 concentration";
            }
            return str;
        }
        public static string alarm_sound_paused()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "报警声音暂停";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Alarm sound paused";
            }
            return str;
        }
        public static string power_source_switched()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "供电电源切换,";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Power source switched,";
            }
            return str;
        }
        public static string AC_source()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "AC电源";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "AC";
            }
            return str;
        }
        public static string bat()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "电池";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Battery";
            }
            return str;
        }
        public static string pre_use_check_pass()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "Pre-use check:PASS,";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Pre-use check:PASS,";
            }
            return str;
        }
        public static string pre_use_check_fail()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "Pre-use check:FAIL,";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Pre-use check:FAIL,";
            }
            return str;
        }
        public static string _6Pin_circle_ID()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "回路ID";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "6Pin circle ID";
            }
            return str;
        }
        public static string patient_temperature()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "患者端温度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Patient temperature";
            }
            return str;
        }
        public static string outlet_temperature()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "出气口温度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Outlet temperature";
            }
            return str;
        }
        public static string ambient_temperature()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "环境温度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Ambient temperature";
            }
            return str;
        }
        public static string _6Pin_circle_resistor()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "回路电阻";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "6Pin circle resistor";
            }
            return str;
        }
        public static string OK()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "OK";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "OK";
            }
            return str;
        }
        public static string NG()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "NG";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "NG";
            }
            return str;
        }
        public static string water_level_check()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "水位检查";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Water level check";
            }
            return str;
        }
        public static string leak_check()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "漏气检查";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Leak check";
            }
            return str;
        }
        public static string device_boot_up()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "设备开机";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Device boot up";
            }
            return str;
        }
        public static string set_para()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "设置参数";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "set para";
            }
            return str;
        }
        public static string baby_mode()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "儿童模式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Pediatric Mode";
            }
            return str;
        }
        public static string adult_mode()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "成人模式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Adult Mode";
            }
            return str;
        }
        public static string high_O2Con_alarm_limit()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "高氧浓度报警限值";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "High oxygen concentration alarm limit";
            }
            return str;
        }
        public static string low_O2Con_alarm_limit()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "低氧浓度报警限值";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Low oxygen concentration alarm limit";
            }
            return str;
        }
        public static string power_source()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "供电方式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Power source";
            }
            return str;
        }
        public static string blender_mode()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "空氧混合方式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Blender Mode";
            }
            return str;
        }
        public static string manual()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "手动";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Manual";
            }
            return str;
        }
        public static string auto()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "自动";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Auto";
            }
            return str;
        }
        public static string set_O2Con()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "设置氧浓度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Set oxygen concentration";
            }
            return str;
        }
        public static string alarm_set_changed()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "报警设置被改变";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Alarm set changed";
            }
            return str;
        }
        public static string from()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "从";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "changed from";
            }
            return str;
        }
        public static string to()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "改为";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "to";
            }
            return str;
        }
        public static string change_to()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "改为";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "changed to";
            }
            return str;
        }
        public static string power_off()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "关机";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "power off";
            }
            return str;
        }
        public static string selfcheck()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "开机自检";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "selfcheck";
            }
            return str;
        }
        public static string pre_use_check()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "Pre use check";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "Pre use check";
            }
            return str;
        }
        public static string pause()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "暂停";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "pause";
            }
            return str;
        }
        public static string run()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "运行";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "run";
            }
            return str;
        }
        public static string transmode()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "转运模式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "trans mode";
            }
            return str;
        }
        public static string cooling_down_mode()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "冷却模式";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "cooling down mode";
            }
            return str;
        }
        public static string low_flow_mode_pause()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "低流量模式暂停";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "low flow mode pause";
            }
            return str;
        }
        public static string low_flow_mode_run()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "低流量模式运行";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "low flow mode run";
            }
            return str;
        }
        public static string workstate()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "工作状态";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "work state";
            }
            return str;
        }
        public static string treatment_para_changed()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "治疗参数被改变";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "treatment para changed";
            }
            return str;
        }
        public static string temperature()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "温度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "temperature";
            }
            return str;
        }
        public static string flow()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "流量";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "flow";
            }
            return str;
        }
        public static string O2Con()
        {
            string str = "";
            if (m_lang == LANGUAGE.CHINESE)
            {
                str = "氧浓度";
            }
            else if (m_lang == LANGUAGE.ENGLISH)
            {
                str = "oxygen concentration";
            }
            return str;
        }
        
    }
}
