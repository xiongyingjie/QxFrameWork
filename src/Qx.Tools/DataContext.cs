using System.Collections.Generic;

namespace Qx.Tools
{
    public class DataContext
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
      
        public int UserType { get; set; }
        public bool IsLogin { get; set; }
        public bool IsEmployee { get; set; }// = false;
        public bool IsEnterprise { get; set; }// = false;
        public bool IsTeacher { get; set; } //= false;
        public bool IsStudent { get; set; } //= false;
        public bool IsSchool { get; set; } //= false;
        public bool IsPlatform { get; set; } //= false;
        public string UserUnit { get; set; }
        public string SchoolID { get; set; }
        public string PracBatchID { get; set; }
        private Dictionary<string, object> UserData { get; set; }
        public void SetFiled(string key, object value)
        {
            if (UserData == null)
            {
                UserData = new Dictionary<string, object>() { { key, value } };
            }
            else if (UserData.ContainsKey(key))
            {
                UserData[key] = value;
            }
            else
            {
                UserData.Add(key, value);
            }
        }
        public object GetFiled(string key)
        {
            if (UserData == null || !UserData.ContainsKey(key))
            {
                return null;
            }
            else
            {
                return UserData[key];
            }
        }
    }
}
