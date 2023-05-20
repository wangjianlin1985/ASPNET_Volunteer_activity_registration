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
    ///Member 的摘要说明：团员实体
    /// </summary>

    public class Member
    {
        /*记录id*/
        private int _memberId;
        public int memberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        /*申请团体*/
        private string _groupObj;
        public string groupObj
        {
            get { return _groupObj; }
            set { _groupObj = value; }
        }

        /*申请用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*申请时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

        /*审核状态*/
        private string _shenHeState;
        public string shenHeState
        {
            get { return _shenHeState; }
            set { _shenHeState = value; }
        }

        /*备注信息*/
        private string _memberMemo;
        public string memberMemo
        {
            get { return _memberMemo; }
            set { _memberMemo = value; }
        }

    }
}
