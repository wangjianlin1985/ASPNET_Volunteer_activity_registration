using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///SignUp 的摘要说明：活动报名实体
    /// </summary>

    public class SignUp
    {
        /*报名id*/
        private int _signUpId;
        public int signUpId
        {
            get { return _signUpId; }
            set { _signUpId = value; }
        }

        /*报名活动*/
        private int _huodongObj;
        public int huodongObj
        {
            get { return _huodongObj; }
            set { _huodongObj = value; }
        }

        /*报名用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*报名时间*/
        private DateTime _signUpTime;
        public DateTime signUpTime
        {
            get { return _signUpTime; }
            set { _signUpTime = value; }
        }

        /*执行状态*/
        private string _executeState;
        public string executeState
        {
            get { return _executeState; }
            set { _executeState = value; }
        }

        /*备注信息*/
        private string _signUpMemo;
        public string signUpMemo
        {
            get { return _signUpMemo; }
            set { _signUpMemo = value; }
        }

    }
}
