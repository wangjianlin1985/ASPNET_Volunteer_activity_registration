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
    ///GroupInfo 的摘要说明：组织团体实体
    /// </summary>

    public class GroupInfo
    {
        /*领队用户名*/
        private string _groupUserName;
        public string groupUserName
        {
            get { return _groupUserName; }
            set { _groupUserName = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*团体名称*/
        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        /*领队姓名*/
        private string _leageName;
        public string leageName
        {
            get { return _leageName; }
            set { _leageName = value; }
        }

        /*组织照片*/
        private string _groupPhoto;
        public string groupPhoto
        {
            get { return _groupPhoto; }
            set { _groupPhoto = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*成立日期*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*截止日期*/
        private DateTime _endDate;
        public DateTime endDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /*团队介绍*/
        private string _groupDesc;
        public string groupDesc
        {
            get { return _groupDesc; }
            set { _groupDesc = value; }
        }

    }
}
