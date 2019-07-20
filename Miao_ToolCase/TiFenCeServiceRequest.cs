using Miao_ToolCase.TiFenCeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Miao_ToolCase
{
    public class TiFenCeServiceRequest
    {
        /// <summary>
        /// 执行
        /// </summary>
        public void Process()
        {
            using (var service = new TiFenCeServiceClient())
            {
                var knowledgePointIds = new int[] { 1, 2, 3, 4, 5, 6 };
                var request = new SubmitTiFenCeRequestByEARSRequest();
                request.MotkUserId = "";
                request.UserName = "";
                request.ExamName = "";
                request.UserTrueName = string.Empty;
                request.GradeId = 0;
                request.CourseTypeId = 0;
                request.SchoolName = "";
                request.ClassName = "";
                request.LocationId = 0;
                request.CourseId = 0;
                request.WorkTotalScore = 100;
                request.JuanZiTypeId = 1;
                request.IsForecastExam = 0;
                request.CreationUserId = 0;
                request.WorkInfos = new List<StudentWorkInfo>() {
                    new StudentWorkInfo(){ QuestionNumber =1, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =0},
                    new StudentWorkInfo(){ QuestionNumber =2, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =0},
                    new StudentWorkInfo(){ QuestionNumber =3, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =10 },
                    new StudentWorkInfo(){ QuestionNumber =4, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =10 },
                    new StudentWorkInfo(){ QuestionNumber =5, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =10 },
                    new StudentWorkInfo(){ QuestionNumber =6, KnowledgePointIds= knowledgePointIds,FullScore=10,StudentScore =0}
                }.ToArray();
                var result = service.SubmitTiFenCeRequestByEARS(request);
            }

        }
    }
}
