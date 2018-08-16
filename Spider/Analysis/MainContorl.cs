using DataSpider.Page;
using Spider.Common;
using Spider.DbHelp;
using Spider.Log;
using Spider.Page;
using Spider.Reg;
using Spider.Spider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Analysis
{
    public class MainContorl
    {

        public void HousePortalAnalysis(PageContentEntity entity)
        {
            try
            {
                string pContent = entity.PContent;
                ClsPageUrl clsPageUrl = new ClsPageUrl();
                Utilities util = new Utilities();
                SqlBuild sqlBuild = new SqlBuild();
                SqlPara sqlPara = new SqlPara();
                ClsDB clsDB = new ClsDB();
                RegFunc rf = new RegFunc();

     
                ArrayList arrayList = rf.GetStrArr(pContent, "\"id\":", ",");
                for (int k = 0; k < arrayList.Count; k++)
                {
          

                }



                string KeyWord = entity.KeyWord;
                decimal num;
                DateTime dt;
                string postDataStr = "";
                pContent = rf.GetStr(pContent, "/共有", "页");
                if (pContent != "")
                {
                    for (int i = 1; i <= Convert.ToInt32(pContent); i++)
                    //for (int i = 1; i <= 1; i++)
                    {
                 //       clsPageUrl.AddPageUrl(entity.ProgramName, entity.KeyWord, entity.PID, "Batch", entity.SiteUrl, entity.Url, "http://218.14.207.76/xxgs/xmlpzs/webissue.asp?page=" + i,
                 //"GET", "", entity.EnCode, i.ToString(), entity.CookieContent, entity.AContent, entity.TrySpiderTimes, entity.Depth + 1);
                    }
                }
                else
                {
                    throw new Exception("分析数据失败:页面没有数据");
                }

            }
            catch (Exception ex)
            {
                ClsLog clsLog = new ClsLog();
                clsLog.AddLog(DateTime.Now.ToString(), "分析数据失败" + ex.ToString());
                clsLog.AddLog(DateTime.Now.ToString(), entity.SType + ";" + entity.Url + ";");
                UrlContorl urlContorl = new UrlContorl();
                urlContorl.SaveUrl(entity, ex.ToString());
            }
        }
    }
}
