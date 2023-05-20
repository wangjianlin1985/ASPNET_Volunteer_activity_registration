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
    ///Huodong ��ժҪ˵�����ʵ��
    /// </summary>

    public class Huodong
    {
        /*�id*/
        private int _huodongId;
        public int huodongId
        {
            get { return _huodongId; }
            set { _huodongId = value; }
        }

        /*�����*/
        private int _huodongTypeObj;
        public int huodongTypeObj
        {
            get { return _huodongTypeObj; }
            set { _huodongTypeObj = value; }
        }

        /*�����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*�ͼƬ*/
        private string _huodongPhoto;
        public string huodongPhoto
        {
            get { return _huodongPhoto; }
            set { _huodongPhoto = value; }
        }

        /*����*/
        private string _huodongDesc;
        public string huodongDesc
        {
            get { return _huodongDesc; }
            set { _huodongDesc = value; }
        }

        /*��ʼʱ��*/
        private DateTime _startTime;
        public DateTime startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /*����ʱ��*/
        private DateTime _endTime;
        public DateTime endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /*�����*/
        private float _jifen;
        public float jifen
        {
            get { return _jifen; }
            set { _jifen = value; }
        }

        /*������֯*/
        private string _groupObj;
        public string groupObj
        {
            get { return _groupObj; }
            set { _groupObj = value; }
        }

    }
}
