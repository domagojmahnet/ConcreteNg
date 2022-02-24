import { UserTypeEnum } from "../enums/user-type";

export interface User {
    UserId: number;
    FirstName: string;
    LastName: string;
    Username: string;
    Password: string;
    Phone: string;
    HireDate: Date;
    UserType: UserTypeEnum;
}
