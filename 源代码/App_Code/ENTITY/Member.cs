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
    ///Member ��ժҪ˵������Աʵ��
    /// </summary>

    public class Member
    {
        /*��¼id*/
        private int _memberId;
        public int memberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        /*��������*/
        private string _groupObj;
        public string groupObj
        {
            get { return _groupObj; }
            set { _groupObj = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

        /*���״̬*/
        private string _shenHeState;
        public string shenHeState
        {
            get { return _shenHeState; }
            set { _shenHeState = value; }
        }

        /*��ע��Ϣ*/
        private string _memberMemo;
        public string memberMemo
        {
            get { return _memberMemo; }
            set { _memberMemo = value; }
        }

    }
}
