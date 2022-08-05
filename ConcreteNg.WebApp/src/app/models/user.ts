import { UserTypeEnum } from "../enums/user-type";

export interface User {
    userId: number;
    firstName: string;
    lastName: string;
    username: string;
    password: string;
    phone: string;
    hireDate: Date;
    userType: UserTypeEnum;
    isActive: boolean;
}
