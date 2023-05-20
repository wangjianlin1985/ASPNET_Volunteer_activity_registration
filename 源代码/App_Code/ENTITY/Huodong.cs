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
    ///Huodong 的摘要说明：活动实体
    /// </summary>

    public class Huodong
    {
        /*活动id*/
        private int _huodongId;
        public int huodongId
        {
            get { return _huodongId; }
            set { _huodongId = value; }
        }

        /*活动类型*/
        private int _huodongTypeObj;
        public int huodongTypeObj
        {
            get { return _huodongTypeObj; }
            set { _huodongTypeObj = value; }
        }

        /*活动名称*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*活动图片*/
        private string _huodongPhoto;
        public string huodongPhoto
        {
            get { return _huodongPhoto; }
            set { _huodongPhoto = value; }
        }

        /*活动简介*/
        private string _huodongDesc;
        public string huodongDesc
        {
            get { return _huodongDesc; }
            set { _huodongDesc = value; }
        }

        /*开始时间*/
        private DateTime _startTime;
        public DateTime startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /*结束时间*/
        private DateTime _endTime;
        public DateTime endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /*活动积分*/
        private float _jifen;
        public float jifen
        {
            get { return _jifen; }
            set { _jifen = value; }
        }

        /*发布组织*/
        private string _groupObj;
        public string groupObj
        {
            get { return _groupObj; }
            set { _groupObj = value; }
        }

    }
}
