using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Miao_ToolCase.Model
{
    public class Test
    {
        public class CreateReportInOneStepRequest
        {
            /// <summary>
            /// 机构编码
            /// </summary>

            public int OrganizationCode { get; set; }

            /// <summary>
            /// 试卷Id
            /// </summary>

            public int JuanZiId { get; set; }

            /// <summary>
            /// 试卷名称
            /// </summary>

            public string JuanZiName { get; set; }

            /// <summary>
            /// 学科ID
            /// </summary>

            public int CourseId { get; set; }

            /// <summary>
            /// 年级ID
            /// </summary>

            public int GradeId { get; set; }

            /// <summary>
            /// 地区ID
            /// </summary>

            public int LocationId { get; set; }

            /// <summary>
            /// 试卷类型Id
            /// </summary>

            public int JuanZiTypeId { get; set; }

            /// <summary>
            /// 试卷来源类型,<see cref="ReadCommentTypeEnum"/>
            /// </summary>

            public int ReadCommentTypeId { get; set; }

            /// <summary>
            /// 报告Logo
            /// </summary>

            public byte[] ReportLogo { get; set; }

            /// <summary>
            /// 报告Logo地址
            /// </summary>

            public string ReportLogoPath { get; set; }

            /// <summary>
            /// 是否包含错题本模块
            /// </summary>

            public bool IncludeWrongNoteBookModule { get; set; }

            /// <summary>
            /// 题目集合
            /// </summary>

            public List<JuanZiQuestionInfoRequest> JuanZiQuestionInfos { get; set; }

            /// <summary>
            /// 学生信息及得分集合
            /// </summary>

            public List<StudentScoreInfoRequest> StudentScoreInfos { get; set; }
        }
        /// <summary>
        /// 试卷题目信息
        /// </summary>
        [DataContract]
        public class JuanZiQuestionInfoRequest
        {
            /// <summary>
            /// 题号
            /// </summary>
            [DataMember]
            public int QuestionNumber { get; set; }

            /// <summary>
            /// 对应motk 题目id
            /// </summary>
            [DataMember]
            public int QuestionId { get; set; }

            /// <summary>
            /// 小题满分
            /// </summary>
            [DataMember]
            public double FullScore { get; set; }

            /// <summary>
            /// 选做题Id
            /// </summary>
            [DataMember]
            public int ChooseQuestionGroupId { get; set; }
        }

        /// <summary>
        /// 学生信息
        /// </summary>
        [DataContract]
        public class StudentScoreInfoRequest
        {
            /// <summary>
            /// 用户真实姓名
            /// </summary>
            [DataMember]
            public string UserTrueName { get; set; }

            /// <summary>
            /// 考生号
            /// </summary>
            [DataMember]
            public string StudentNo { get; set; }

            /// <summary>
            /// 学校名称
            /// </summary>
            [DataMember]
            public string SchoolName { get; set; }

            /// <summary>
            /// 班级名称
            /// </summary>
            [DataMember]
            public string ClassName { get; set; }

            /// <summary>
            /// 学生得分集合
            /// </summary>
            [DataMember]
            public List<GetScoreInfoRequest> GetScoreInfoRequests { get; set; }
        }

        /// <summary>
        /// 得分集合
        /// </summary>
        [DataContract]
        public class GetScoreInfoRequest
        {
            /// <summary>
            /// 题目序号
            /// </summary>
            [DataMember]
            public int QuestionNumber { get; set; }

            /// <summary>
            /// 得分
            /// </summary>
            [DataMember]
            public double Score { get; set; }

            /// <summary>
            /// [非必填字段]
            /// 学生作答信息，适用于阅卷系统通过答题卡提交成绩生成报告，内容为html
            /// 主观题答案：A、对/错
            /// <![CDATA[客观题：一张或多张图片<img src="http://xxxxx">]]> 
            /// </summary>
            [DataMember]
            public string StudentAnswer { get; set; }
        }
    }
}
