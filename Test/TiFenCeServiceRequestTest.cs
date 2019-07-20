using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TiFenCeService;

namespace Test
{
    [TestClass]
    public class TiFenCeServiceRequestTest
    {


        [TestMethod]
        public void TestMethod1()
        {
            using (var service = new TiFenCeServiceClient())
            {
                var knowledgePointIds = new List<int> { 1, 2, 3, 4, 5, 6 };
                var request = new SubmitTiFenCeRequestByEARSRequest();
                request.MotkUserId = 51154571;
                request.ExamName = "程序狗";
                request.UserTrueName = "盲僧点灯";
                request.GradeId = 0;
                request.CourseTypeId = 0;
                request.SchoolName = "";
                request.ClassName = "";
                request.LocationId = 0;
                request.CourseId = 12;
                request.WorkTotalScore = 100;
                request.JuanZiTypeId = 1;
                request.IsForecastExam = 0;
                request.WorkInfos = new List<StudentWorkInfo>()
                {
                    new StudentWorkInfo(){ QuestionNumber =1, KnowledgePointIds= new List<int>{ 10003 } ,FullScore=10,StudentScore =1},
                    new StudentWorkInfo(){ QuestionNumber =2, KnowledgePointIds=  new List<int>{ 10002 },FullScore=10,StudentScore =1},
                    new StudentWorkInfo(){ QuestionNumber =3, KnowledgePointIds=  new List<int>{ 10002 },FullScore=10,StudentScore =1 },
                    new StudentWorkInfo(){ QuestionNumber =4, KnowledgePointIds=  new List<int>{ 10002 },FullScore=10,StudentScore =1 },
                };
                // service.Timeout = 300000; // 单位是毫秒，设置时间，否则时间超限
                var requestId = service.SubmitTiFenCeRequestByEARS(request);
            }
        }


        [TestMethod]
        public void TestMethod2()
        {
            using (var service = new TiFenCeServiceClient())
            {
                int requestId = 5001;
                var result = service.GetSingleEARSUserTiFenCePdfUrl(requestId);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            string json = "{ \"ClassName\":null,\"CourseId\":2,\"CourseTypeId\":1,\"ExamName\":\"测试测试111111\",\"GradeId\":3,\"IsForecastExam\":1,\"JuanZiTypeId\":1,\"LocationId\":373,\"MotkUserId\":51155876,\"SchoolName\":null,\"UserTrueName\":\"冯梓嘉\",\"WorkInfos\":[{\"FullScore\":10.0,\"KnowledgePointIds\":[15652],\"QuestionNumber\":1,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":2,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":3,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":4,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":5,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":6,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":7,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":8,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":9,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":10,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":11,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":12,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":13,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":14,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":15,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":16,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":17,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":18,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":19,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":20,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":21,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":22,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":23,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":24,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":25,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11307],\"QuestionNumber\":26,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":27,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":28,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":29,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":30,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":31,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":32,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":33,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":34,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":35,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":36,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":37,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":38,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":39,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":40,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":41,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":42,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":43,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":44,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":45,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":46,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":47,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":48,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":49,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":50,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":51,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15623],\"QuestionNumber\":52,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":53,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":54,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":55,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":56,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":57,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":58,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":59,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":60,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":61,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":62,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":63,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":64,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":65,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":66,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":67,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":68,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":69,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":70,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":71,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":72,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15657],\"QuestionNumber\":73,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15659],\"QuestionNumber\":74,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":75,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":76,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":77,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":78,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":79,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":80,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":81,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":82,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":83,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":84,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":85,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":86,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":87,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":88,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":89,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":90,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":91,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15704],\"QuestionNumber\":92,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":93,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":94,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":95,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":96,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":97,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11326],\"QuestionNumber\":98,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[13708],\"QuestionNumber\":99,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":100,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11323],\"QuestionNumber\":101,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":102,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15820],\"QuestionNumber\":103,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":104,\"StudentScore\":10.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":105,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":106,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[11327],\"QuestionNumber\":107,\"StudentScore\":0.0},{\"FullScore\":10.0,\"KnowledgePointIds\":[15754],\"QuestionNumber\":108,\"StudentScore\":0.0}],\"WorkTotalScore\":100.0}";
            var request = JsonHelper.Deserialize<SubmitTiFenCeRequestByEARSRequest>(json);
            using (var service = new TiFenCeServiceClient())
            {
                var requestId = service.SubmitTiFenCeRequestByEARS(request);
            }


        }
        [TestMethod]
        public void TestMethod4()
        {
            DateTime dateStart = DateTime.Now;
            var date = DateTime.Now.AddDays(0);
            DateTime dateEnd = new DateTime(date.Year, date.Month, date.Day, 15, 02, 59);
            TimeSpan sp = dateEnd.Subtract(dateStart);
            var reulst = sp.Days == 0 ? sp.TotalSeconds > 0 ?  1 : 0 : sp.Days + 1;



            int day = (dateEnd - dateStart).Seconds;

            var start = Convert.ToDateTime(dateStart.ToShortDateString());
            var end = Convert.ToDateTime(dateEnd.ToShortDateString());
            var spday = dateEnd.Subtract(dateStart).Days;
        }
    }
}
