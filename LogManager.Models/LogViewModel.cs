using System;

namespace LogManager.Models
{
    /// <summary>
    /// Logs 테이블과 일대일로 매핑되는 모델(뷰 모델, 엔터티) 클래스
    /// </summary>
    public class LogViewModel
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Id                           { get; set; }

        /// <summary>
        /// 비고
        /// </summary>
        public string Note                      { get; set; }

        /// <summary>
        /// 응용 프로그램: 게시판 관리, 상품 관리
        /// </summary>
        public string Application               { get; set; }

        /// <summary>
        /// 사용자 정보(로그인 사용 아이디)
        /// </summary>
        public string Logger			        { get; set; }

        /// <summary>
        /// 로그 이벤트(사용자 정의 이벤트 ID)
        /// </summary>
        public string LogEvent			        { get; set; }

        /// <summary>
        /// 로그 메시지 
        /// </summary>
        public string Message			        { get; set; }

        /// <summary>
        /// 로그 메시지에 대한 템플릿
        /// </summary>
        public string MessageTemplate	        { get; set; }

        /// <summary>
        /// 로그 레벨(정보, 에러, 경고)
        /// </summary>
        public string Level				        { get; set; }

        /// <summary>
        /// 로그 발생 시간(LogCreationDate)
        /// </summary>
        public DateTimeOffset TimeStamp	        { get; set; }

        /// <summary>
        /// 예외 메시지 
        /// </summary>
        public string Exception			        { get; set; }

        /// <summary>
        /// 기타 여러 속성들을 XML 저장
        /// </summary>
        public string Properties		        { get; set; }

        /// <summary>
        /// 호출사이트
        /// </summary>
        public string Callsite			        { get; set; }

        /// <summary>
        /// IP 주소
        /// </summary>
        public string IpAddress			        { get; set; }
    }
}
