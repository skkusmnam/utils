using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace DEVS_Setup
{
    class Global
    {
        #region 레지스트리 키 생성
        public RegistryKey CreateSubKey()
        {
            RegistryKey rkey = Registry.CurrentUser.CreateSubKey("DEVS_Setup");

            return rkey;
        }
        #endregion

        #region 레지스트리 두번째 서브 키 생성
        public RegistryKey CreateSubKey(string subkey)
        {
            RegistryKey rkey = Registry.CurrentUser.CreateSubKey("DEVS_Setup").CreateSubKey(subkey);

            return rkey;
        }
        #endregion

        #region 레지스트리 오픈
        public RegistryKey OpenSubKey()
        {
            RegistryKey rkey;
            
            object b = Registry.CurrentUser.OpenSubKey("DEVS_Setup");

            if (b == null)
            {
                rkey = Registry.CurrentUser.CreateSubKey("DEVS_Setup");
            }
            else
            {
                rkey = Registry.CurrentUser.OpenSubKey("DEVS_Setup");
            }
            return rkey;
        }
        #endregion

        #region 레지스트리 값 서브키에 설정
        public void SetValue(string Name, string Value)
        {
            RegistryKey rkey = Registry.CurrentUser.CreateSubKey("DEVS_Setup");

            rkey.SetValue(Name, Value);
        }
        #endregion

        #region 레지스트리 값 두번째 서브키에 설정
        public void SetValue(string Name, string Value, string subkey)
        {
            RegistryKey rkey = Registry.CurrentUser.CreateSubKey("DEVS_Setup").CreateSubKey(subkey);

            rkey.SetValue(Name, Value);
        }
        #endregion

        #region 레지스트리 값 얻기
        public void GetValue(string Name, out string Value)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey("DEVS_Setup", true);

            try
            {
                Value = rkey.GetValue(Name).ToString();
            }
            catch
            {
                Value = "";

                switch (Name)
                {
                    case "MainPath":
                        Value = @"C:\DEVS_ObjectC";
                        break;
                    case "DEVSDiagramDisplayPath":
                        Value = @"C:\DEVS_ObjectC\DEVS_DD.exe";
                        break;
                    case "DEVSObjectPath":
                        Value = @"C:\DEVS_ObjectC\framework";
                        break;
                    case "SESEditorPath":
                        Value = @"C:\DEVS_ObjectC\SES_Editor.exe";
                        break;
                }

            }
        }
        #endregion

        #region 레지스트리 두번째 서브키 값 얻기
        public void GetValue(string Name, out string Value, string subkey)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey("DEVS_Setup", true).OpenSubKey(subkey, true);

            try
            {
                Value = rkey.GetValue(Name).ToString();
            }
            catch
            {
                Value = "";
            }
        }
        #endregion
    }
}
