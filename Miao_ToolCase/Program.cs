using EF.Model.CodeFristDemo;
using Knowledge_Point知识点.MEF;
using Miao_ToolCase.Action;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Unity.Interception.Utilities;
using Utils工具;
using static Miao_ToolCase.Model.Test;

namespace Miao_ToolCase
{
    public class Program
    {

        public class ResponseTicketQuery
        {
            public string httpstatus { get; set; }

            public string messages { get; set; }

            public bool status { get; set; }

            public string c_name { get; set; }

            public string c_url { get; set; }


            public TrainQueryData data { get; set; }
        }

        public class TrainQueryData
        {
            public string flag { get; set; }

            public object map { get; set; }

            public string[] result { get; set; }
        }




        static void Main(string[] args)
        {

            string str = (100.001 % 1).ToString("F1");

            var a = Math.Round(23.100000381469727, 2);
            int b = (int)100.9;
            var c = 100.001 % 1;

            ShowInterface showInterface = new AsposeWordShow();
            showInterface.Show();


            //Model1 model1 = new Model1();
            //var cc = model1.TB_Category.Count();



            //foreach (var item in tt)
            //{
            //    Console.WriteLine(item.Key + "====" );
            //    Console.WriteLine("<br />");
            //}

            //MEF_Realize ss = new MEF_Realize();
            //string a = UrlDecodeRecordId("1,2,3,4"); ;
            //string b = a.Split('_')[1];

            //a = "123_456";
            ////从下一个索引开始截取
            //string c = a.Substring(a.LastIndexOf('_') + 1);

            ////var list = GetScoreInfoRequest(5);


            ////var s = list.GroupBy(x => x.Score).ToList();
            //Console.WriteLine();
        }
        /// <summary>
        /// 多个连续字段解密
        /// </summary>
        /// <param name="recordIds"></param>
        /// <returns></returns>
        private static string UrlDecodeRecordId(string recordIds)
        {
            string[] sArray = Regex.Split(recordIds, ",", RegexOptions.IgnoreCase);
            string recordId = string.Empty;
            sArray.ForEach(x => recordId += x + "a" + ",");
            return recordId.TrimEnd(',');
        }

        public void CreateReportInOneStepRequest()
        {
            CreateReportInOneStepRequest req = new CreateReportInOneStepRequest();
            req.OrganizationCode = 25477;
            req.JuanZiId = 4298;
            req.JuanZiName = "高三物理-高考-河南";
            req.CourseId = 12;
            req.GradeId = 6;
            req.LocationId = 424;
            req.JuanZiTypeId = 3;
            req.ReadCommentTypeId = 2;
            req.ReportLogoPath = "";
            req.IncludeWrongNoteBookModule = true;
            req.JuanZiQuestionInfos = JuanZiQuestionInfoRequest();
            req.StudentScoreInfos = StudentScoreInfo(3);
            var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(req, Newtonsoft.Json.Formatting.None, jSetting);
        }

        public static List<JuanZiQuestionInfoRequest> JuanZiQuestionInfoRequest()
        {
            var juanZiQuestionInfo = new List<JuanZiQuestionInfoRequest>();

            JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();

            juanZi.QuestionNumber = 1;
            juanZi.QuestionId = 75731073;
            juanZi.FullScore = 5;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 2;
            juanZi.QuestionId = 76051409;
            juanZi.FullScore = 5;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 3;
            juanZi.QuestionId = 76047576;
            juanZi.FullScore = 5;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 4;
            juanZi.QuestionId = 76050940;
            juanZi.FullScore = 5;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 5;
            juanZi.QuestionId = 75935329;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 6;
            juanZi.QuestionId = 76027944;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 7;
            juanZi.QuestionId = 75190189;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 8;
            juanZi.QuestionId = 75732056;
            juanZi.FullScore = 20;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 9;
            juanZi.QuestionId = 75732987;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 10;
            juanZi.QuestionId = 75775234;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 11;
            juanZi.QuestionId = 75926602;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 12;
            juanZi.QuestionId = 75932086;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZi.QuestionNumber = 13;
            juanZi.QuestionId = 75889999;
            juanZi.FullScore = 10;
            juanZiQuestionInfo.Add(juanZi);

            juanZiQuestionInfo.ForEach(x => x.ChooseQuestionGroupId = 0);

            return juanZiQuestionInfo;
        }



        public static List<StudentScoreInfoRequest> StudentScoreInfo(int count)
        {
            var studentScoreInfos = new List<StudentScoreInfoRequest>();
            for (int i = 0; i < count; i++)
            {
                StudentScoreInfoRequest student = new StudentScoreInfoRequest
                {
                    UserTrueName = "打手的" + i,
                    StudentNo = "we20190103161700" + i,
                    GetScoreInfoRequests = GetScoreInfoRequest(13)
                };
                studentScoreInfos.Add(student);
            }

            return studentScoreInfos;
        }


        public static List<GetScoreInfoRequest> GetScoreInfoRequest(int count)
        {
            List<GetScoreInfoRequest> GetScoreInfoRequests = new List<GetScoreInfoRequest>();
            for (int i = 0; i < count; i++)
            {
                GetScoreInfoRequest getScore = new GetScoreInfoRequest();
                getScore.QuestionNumber = i;
                getScore.Score = 5;
                GetScoreInfoRequests.Add(getScore);
            }
            return GetScoreInfoRequests;
        }





        public static int GetEnumValue(Type enumType, string enumName)
        {
            try
            {
                if (!enumType.IsEnum)
                    throw new ArgumentException("enumType必须是枚举类型");
                var values = Enum.GetValues(enumType);
                var ht = new Hashtable();
                foreach (var val in values)
                {
                    ht.Add(Enum.GetName(enumType, val), val);
                }
                return (int)ht[enumName];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        enum Page
        {
            page1 = 99,
            page2 = 2,
            page3 = 1,
            page4 = 98,
            page5 = 4,
            page6 = -1,
            page7 = -2,
            page9 = 2,
            page8 = -3,
        }

        public static string XmlSerialize<T>(T obj)
        {
            string OutputXmlString = string.Empty;
            var setting = new XmlWriterSettings() { Encoding = new UTF8Encoding(false), Indent = true, };
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                XmlDocument myXmlDoc = new XmlDocument();
                serializer.Serialize(sw, obj);
                sw.Close();
                OutputXmlString = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(sw.ToString())); ;
                return OutputXmlString;
            }
        }


    }
}
