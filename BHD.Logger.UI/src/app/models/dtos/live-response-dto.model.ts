import { Log } from "../log.model";

export interface LiveResponseDto{
    latestTime: Date,
    logs: Log[]
}