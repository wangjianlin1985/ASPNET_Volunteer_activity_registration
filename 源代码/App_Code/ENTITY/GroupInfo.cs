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
    ///GroupInfo ��ժҪ˵������֯����ʵ��
    /// </summary>

    public class GroupInfo
    {
        /*����û���*/
        private string _groupUserName;
        public string groupUserName
        {
            get { return _groupUserName; }
            set { _groupUserName = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*��������*/
        private string _groupName;
        public string groupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        /*�������*/
        private string _leageName;
        public string leageName
        {
            get { return _leageName; }
            set { _leageName = value; }
        }

        /*��֯��Ƭ*/
        private string _groupPhoto;
        public string groupPhoto
        {
            get { return _groupPhoto; }
            set { _groupPhoto = value; }
        }

        /*��ϵ�绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*��������*/
        private DateTime _bornDate;
        public DateTime bornDate
        {
            get { return _bornDate; }
            set { _bornDate = value; }
        }

        /*��ֹ����*/
        private DateTime _endDate;
        public DateTime endDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        /*�Ŷӽ���*/
        private string _groupDesc;
        public string groupDesc
        {
            get { return _groupDesc; }
            set { _groupDesc = value; }
        }

    }
}
