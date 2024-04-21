using System;
namespace BHD.LogsHut.DTOs
{
	public class LiveLogsRequestDto
	{
        public DateTime RequestTime { get; set; }  
        public bool IsFirstCall { get; set; }
	}
}

