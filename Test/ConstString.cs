using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Test
{
    /// <summary>
    /// 用于Session的常量字符串
    /// </summary>
    public static class ConstString
    {
        /// <summary>
        /// 标的进度
        /// </summary>
        public const string BidProgress = "BidProgress";
        /// <summary>
        /// 后台用户登录Id
        /// </summary>
        public const string LoginId = "LoginId";

        /// <summary>
        /// 后台子用户Id集
        /// </summary>
        public const string ChildUids = "ChildUids";

        /// <summary>
        /// 前台用户登录Id
        /// </summary>
        public const string UserLoginId = "UserLoginId";

        /// <summary>
        /// 前台用户登录Guid
        /// </summary>
        public const string UserLoginGuid = "UserLoginGuid";

        /// <summary>
        /// 后台用户登录Guid
        /// </summary>
        public const string UserInfoLoginGuid = "UserInfoLoginGuid";

        /// <summary>
        /// 前台忘记密码验证码
        /// </summary>
        public const string ForgetPassword = "ForgetPassword";

        /// <summary>
        /// 找回密码
        /// </summary>
        public const string FindPassword = "FindPassword";
        /// <summary>
        /// 后台验证码
        /// </summary>
        public const string ValidateCode = "ValidateCode";
        /// <summary>
        /// 前台用户验证码
        /// </summary>
        public const string UserValidateCode = "UserValidateCode";

        /// <summary>
        /// 前台用户注册
        /// </summary>
        public const string UserRegister = "UserRegister";
        /// <summary>
        /// 前台用户注册来源
        /// </summary>
        public const string UserRegisterSource = "UserRegisterSource";

        /// <summary>
        /// 找回密码用户id
        /// </summary>
        public const string FindUserId = "FindUserId";
        /// <summary>
        /// 前台登录验证码
        /// </summary>
        public const string UserLoginValidateCode = "UserLoginValidateCode";
        /// <summary>
        /// 用户登录Cookie
        /// </summary>
        public const string UserLoginCookie = "UserLoginCookie";

        /// <summary>
        /// 用户登录信息
        /// </summary>
        public const string UserLoginInfo = "UserLoginInfo";

        /// <summary>
        /// 修改邮箱验证码
        /// </summary>
        public const string AlterMailCode = "AlterMailCode";

        /// <summary>
        /// 前台修改手机号码
        /// </summary>
        public const string UpdateMobile = "UpdateMobile";

        /// <summary>
        /// 微信注册手机号Session
        /// </summary>
        public const string WeiXinRegMobile = "WeiXinRegMobile";

        /// <summary>
        /// 微信是否已验证旧手机Session
        /// </summary>
        public const string WeiXinIsCheckPhone = "WeiXinIsCheckPhone";

        /// <summary>
        /// 微信是否已验证旧邮箱Session
        /// </summary>
        public const string WeiXinIsCheckEmail = "WeiXinIsCheckEmail";

        /// <summary>
        /// 微信是否已通过验证手机(手机找回交易密码)Session
        /// </summary>
        public const string WeiXinCheckedPhone_PayPwd = "WeiXinCheckedPhone_PayPwd";

        /// <summary>
        /// 微信是否已通过验证手机(手机找回登录密码)Session
        /// </summary>
        public const string WeiXinCheckedPhone_Pwd = "WeiXinCheckedPhone_Pwd";

        /// <summary>
        /// 微信是否已通过验证手机(注册第二步)Session
        /// </summary>
        public const string WeiXinCheckedPhone_Register = "WeiXinCheckedPhone_Register";

        /// <summary>
        /// 微信注册验证码
        /// </summary>
        public const string WeiXinRegCode = "WeiXinRegCode";

        /// <summary>
        /// 微信注册模型Session
        /// </summary>
        public const string WeiXinRegModel = "WeiXinRegModel";

        /// <summary>
        /// 微信登录信息
        /// </summary>
        public const string WeiXinLoginInfo = "WeiXinLoginInfo";
        public const string WeiXinLoginId = "WeiXinLoginId";

        /// <summary>
        /// 微信授权Token
        /// </summary>
        public const string WeiXinAccessToken = "WeiXinAccessToken";

        /// <summary>
        /// 微信API jsapi_ticket
        /// </summary>
        public const string WeiXinJsapiTicket = "WeiXinJsapiTicket";

        /// <summary>
        /// 微信API OpenId
        /// </summary>
        public const string WeiXinOpenId = "WeiXinOpenId";

        /// <summary>
        /// 资金信息部分(公共信息)
        /// </summary>
        //public const string UserPayInfo = "UserPayInfo";


        /// <summary>
        /// 银行卡变更
        /// </summary>
        public const string BankRecord = "BankRecord";


        /// <summary>
        /// 投资结果
        /// </summary>
        public const string InvestResult = "InvestResult";

        /// <summary>
        /// 选择加息劵
        /// </summary>
        public const string SelectLVBond = "SelectLVBond";

        /// <summary>
        /// pc、微信介绍页
        /// </summary>
        public const string Experence = "Experence";
        public const string WeiXinExperence = "WeiXinExperence";
        /// <summary>
        /// 首页弹屏
        /// </summary>
        public const string PCBombScreen = "PCBombScreen";


        /// <summary>
        /// 后台来源Id
        /// </summary>
        public const string ManageFormId = "ManageFormId";


        /// <summary>
        /// PC 修改手机-第一步
        /// </summary>
        public const string UpdateMobileOne = "UpdateMobileOne";


        /// <summary>
        /// PC新版首页注册验证码
        /// </summary>
        public const string PCNewPageRegCode = "PCNewPageRegCode";

        /// <summary>
        /// PC活动推广注册验证码
        /// </summary>
        public const string PCActivityRegCode = "PCActivityRegCode";

        /// <summary>
        /// 微信新版注册验证码
        /// </summary>
        public const string WXNewPageRegCode = "WXNewPageRegCode";

        /// <summary>
        /// 微信春节H5注册验证码
        /// </summary>
        public const string WXFestivalRegCode = "WXFestivalRegCode";

        /// <summary>
        /// 春节H5
        /// </summary>
        public const string H5Festival = "H5Festival";


        /// <summary>
        /// 微信是否已验证身份信息
        /// </summary>
        public const string WeiXinIsCheckSafeCard = "WeiXinIsCheckSafeCard";


        /// <summary>
        /// 借款用户信息第一部分是否验证
        /// </summary>
        public const string WeiXinLoanUserOne = "WeiXinLoanUserOne";
        

        /// <summary>
        /// 借款用户信息第二部分是否验证
        /// </summary>
        public const string WeiXinLoanUserTwo = "WeiXinLoanUserTwo";


        /// <summary>
        /// 后台首次登录强制改密码
        /// </summary>
        public const string ManaFirstLogin = "ManaFirstLogin";
    }


    /// <summary>
    /// 常量,加Admin表示用于后台
    /// </summary>
    public static class ConstValue
    {
        /// <summary>
        /// 运行登录失败的最多错误次数
        /// </summary>
        public const int Login_ErrorCount = 5;

        /// <summary>
        /// 短信发送验证码最多可发送次数
        /// </summary>
        public const int Admin_ValidateCount = 5;

        /// <summary>
        /// 允许用户短信验证失败的次数
        /// </summary>
        public const int Admin_ErrorCount = 5;

        /// <summary>
        /// 可以重新验证的时间间隔，单位分钟
        /// </summary>
        public const int Admin_ValidateInterval = 30;

        /// <summary>
        /// 邮箱验证码的有效时间，单位分钟
        /// </summary>
        public const int EmailValidCodeTime = 10;
        /// <summary>
        /// 前台公司动态类别的Id
        /// </summary>
        public const int CompanyDynamicId = 1044;

        /// <summary>
        /// 前台媒体报道类别的id
        /// </summary>
        public const int MediaReport = 1045;

        /// <summary>
        /// 前台官方通告类别的id
        /// </summary>
        public const int OfficialNotice = 1049;

        /// <summary>
        /// 前台发标公告类别的id
        /// </summary>
        public const int SubjectNotice = 1069;

        /// <summary>
        /// 大事记
        /// </summary>
        public const int LargeEvents = 1065;

        /// <summary>
        /// 视频锦集
        /// </summary>
        public const int VideoCollectionId = 1055;

        /// <summary>
        /// 媒体报告
        /// </summary>
        public const int MediaReportId = 1066;



        /// <summary>
        /// 最小密码长度
        /// </summary>
        public const int MinPwdLength = 6;

        /// <summary>
        /// 最长密码长度
        /// </summary>
        public const int MaxPwdLength = 50;

        /// <summary>
        /// 最小用户名长度
        /// </summary>
        public const int MinUserNameLength = 3;

        /// <summary>
        /// 最长用户名长度
        /// </summary>
        public const int MaxUserNameLength = 20;

        /// <summary>
        /// 手机号码长度
        /// </summary>
        public const int MobileLength = 11;

        /// <summary>
        /// 上传文件的大小(单位字节)
        /// </summary>
        public const int UpFileSize = 1048576;


        /// <summary>
        /// 中旗POS机
        /// </summary>
        public const int ZQ = 4;
        /// <summary>
        /// 钱富通POS机
        /// </summary>
        public const int QFT = 3;
        /// <summary>
        /// 华美居POS机
        /// </summary>
        public const int HMJ = 2;
        /// <summary>
        /// 琦海POS机
        /// </summary>
        public const int QH = 1;

        public const int POST5 = 5;
        public const int POST6 = 6;


        #region 财务数据导入标题
        public const string ImpTypeName = "支付公司";
        public const string ImpOrderNumber = "商户订单号";
        public const string ImpTime = "交易时间";
        public const string ImpMoneyNum = "交易金额";
        public const string ImpPoundage = "手续费";
        #endregion


        #region 客户资金记录统计
        public const string StatisticalUserName = "客户";
        public const string StatisticalFullName = "真实姓名";
        public const string StatisticalTradingTime = "交易时间";
        public const string StatisticalTradingType = "老类型";
        public const string StatisticalRemark = "摘要";
        public const string StatisticalRechargeNum = "充值";
        public const string StatisticalInvestorNum = "投资";
        public const string StatisticalAutoPrize = "奖励";
        public const string StatisticalLZ = "利息";
        public const string StatisticalPaymentNum = "回款";
        public const string StatisticalWithdrawalsNum = "提现";
        public const string StatisticalTtzIn = "天天赚转入";
        public const string StatisticalTtzOn = "天天赚转出";
        public const string StatisticalTtzLV = "天天赚收益";
        public const string StatisticalTtzUsableSum = "天天赚余额";
        #endregion

        //富爸爸接口来源ID
        public const int FBaBaFormId = 1;


        /// <summary>
        /// 金融圈-大额资产项目Id
        /// </summary>
        public const int FinanceProjectId = 1046;
        /// <summary>
        /// 金融圈-已合作资金方Id
        /// </summary>
        public const int FinanceCapitalId = 1047;


        /// <summary>
        /// APP地址
        /// </summary>
        public static readonly string AppIP = "http://localhost:3801/";

        /// <summary>
        /// PC地址
        /// </summary>
        public static readonly string PCIP = "http://localhost:3801/";

        /// <summary>
        /// 后台地址
        /// </summary>
        public static readonly string ManaIP = "http://localhost:3801/";
    }
}
