import { LogLevel } from "../enums/loglevel.enum";

export interface Log {
    time: Date;
    message: string;
    logLevel?: LogLevel;
    source?: string;
    ipAdress?: string;
    exceptionMessage?: string;
    exceptionStack?: string;
}
