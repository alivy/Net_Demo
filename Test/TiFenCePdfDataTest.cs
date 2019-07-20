using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.TiFenCePdfDataService;
using Test.TiMingCe;

namespace Test
{
    [TestClass]
    public class TiFenCePdfDataTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TiFenCePdfDataServiceClient tiFenCePdf = new TiFenCePdfDataServiceClient();
            var tiFenCePdfData = TiFenCePdfData.CreateReportInOneStepRequest();
            var result = tiFenCePdf.CreateReportInOneStep(tiFenCePdfData);
        }
        [TestMethod]
        public void Test2()
        {
            TiFenCePdfDataServiceClient tiFenCePdf = new TiFenCePdfDataServiceClient();
            var tiFenCePdfData = new GetTiFenCeReportListRequest();
            tiFenCePdfData.RecordId = 10;
            var result = tiFenCePdf.GetTiFenCeReportList(tiFenCePdfData);
        }

        [TestMethod]
        public void Test3()
        {
            TiMingCeClient tiMingCe = new TiMingCeClient();
            var courseJuanZiResult = new List<CourseJuanzi>();
            courseJuanZiResult.Add(new CourseJuanzi { CourseId = 13, JuanZiResultId = 209814 });
            courseJuanZiResult.Add(new CourseJuanzi { CourseId = 14, JuanZiResultId = 103279 });
            courseJuanZiResult.Add(new CourseJuanzi { CourseId = 12, JuanZiResultId = 103273 });
            courseJuanZiResult.Add(new CourseJuanzi { CourseId = 11, JuanZiResultId = 103270 });
            courseJuanZiResult.Add(new CourseJuanzi { CourseId = 10, JuanZiResultId = 103267 });
            // courseJuanZiResult.Add(new CourseJuanzi { CourseId = 9, JuanZiResultId = 103264 });
            var request = new GetCreateTiMingCeDocumentRequest
            {
                UserId = 196292,
                ProvinceId = 98,
                ArtsOrScience = ArtsOrScienceEnum.Science,
                TiMingCeType = TiMingCeTypeEnum.HaveSet,
                CourseJuanZiResult = courseJuanZiResult.ToArray()
            };
            string json = JsonHelper.Serialize(request);
            var result = tiMingCe.CreateTiMingCeDocument(request);
            GetWordFile(result.Entity);
        }


        /// <summary>
        /// 用指定二进制数据流生成Word文件到指定路径（如“D:\”），文件名需要带后缀
        /// </summary>
        /// <param name="data"></param>
        public void GetWordFile(byte[] data)
        {
            string Directory = @"d:\temp\test1.docx";
            FileStream fs = new FileStream(Directory, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(data, 0, data.Length);
            bw.Close();
            fs.Close();
        }
    }



    public class TiFenCePdfData
    {
        /// <summary>
        /// 构造对象
        /// </summary>
        /// <returns></returns>
        public static CreateReportInOneStepRequest CreateReportInOneStepRequest()
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
            //req.JuanZiQuestionInfos = JuanZiQuestionInfoRequest();
            //req.StudentScoreInfos = StudentScoreInfo(3);
            return req;
        }

        public static List<JuanZiQuestionInfoRequest> JuanZiQuestionInfoRequest()
        {
            var juanZiQuestionInfo = new List<JuanZiQuestionInfoRequest>();
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 1;
                juanZi.QuestionId = 75731073;
                juanZi.FullScore = 5;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 2;
                juanZi.QuestionId = 76051409;
                juanZi.FullScore = 5;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 3;
                juanZi.QuestionId = 76047576;
                juanZi.FullScore = 5;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 4;
                juanZi.QuestionId = 76050940;
                juanZi.FullScore = 5;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 5;
                juanZi.QuestionId = 75935329;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 6;
                juanZi.QuestionId = 76027944;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 7;
                juanZi.QuestionId = 75190189;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 8;
                juanZi.QuestionId = 75732056;
                juanZi.FullScore = 20;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 9;
                juanZi.QuestionId = 75732987;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 10;
                juanZi.QuestionId = 75775234;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 11;
                juanZi.QuestionId = 75926602;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 12;
                juanZi.QuestionId = 75932086;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
            {
                JuanZiQuestionInfoRequest juanZi = new JuanZiQuestionInfoRequest();
                juanZi.QuestionNumber = 13;
                juanZi.QuestionId = 75889999;
                juanZi.FullScore = 10;
                juanZiQuestionInfo.Add(juanZi);
            }
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
                    UserTrueName = "测试的",
                    StudentNo = "we20190104161700" + i,
                    //GetScoreInfoRequests = GetScoreInfo(13)
                };
                studentScoreInfos.Add(student);
            }
            return studentScoreInfos;
        }


        public static List<GetScoreInfoRequest> GetScoreInfo(int count)
        {
            List<GetScoreInfoRequest> GetScoreInfoRequests = new List<GetScoreInfoRequest>();
            for (int i = 0; i < count; i++)
            {
                GetScoreInfoRequest getScore = new GetScoreInfoRequest();
                getScore.QuestionNumber = i + 1;
                getScore.Score = 5;
                GetScoreInfoRequests.Add(getScore);
            }
            return GetScoreInfoRequests;
        }

    }
}
