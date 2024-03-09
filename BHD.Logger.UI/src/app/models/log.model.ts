import { LogLevel } from "../enums/loglevel.enum";

export interface Log {
    time: Date;
    logLevel?: LogLevel;
    service?: string;
    message: string;
    methodName?: string;
    ipAdress?: string;
    user?: string;
    callStack?: string;
}
