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
    ///SignUp ��ժҪ˵���������ʵ��
    /// </summary>

    public class SignUp
    {
        /*����id*/
        private int _signUpId;
        public int signUpId
        {
            get { return _signUpId; }
            set { _signUpId = value; }
        }

        /*�����*/
        private int _huodongObj;
        public int huodongObj
        {
            get { return _huodongObj; }
            set { _huodongObj = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _signUpTime;
        public DateTime signUpTime
        {
            get { return _signUpTime; }
            set { _signUpTime = value; }
        }

        /*ִ��״̬*/
        private string _executeState;
        public string executeState
        {
            get { return _executeState; }
            set { _executeState = value; }
        }

        /*��ע��Ϣ*/
        private string _signUpMemo;
        public string signUpMemo
        {
            get { return _signUpMemo; }
            set { _signUpMemo = value; }
        }

    }
}
