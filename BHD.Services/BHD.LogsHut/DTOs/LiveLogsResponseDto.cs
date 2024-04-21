using BHD.Logger.Library.Models;

namespace BHD.LogsHut.DTOs;

public class LiveLogsResponseDto
{
    public DateTime LatestTime { get; set; }
    public List<Log>? Logs { get; set; }
}