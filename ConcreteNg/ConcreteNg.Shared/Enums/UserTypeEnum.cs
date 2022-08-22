namespace ConcreteNg.Shared.Enums
{
    [Flags]
    public enum UserTypeEnum
    {
        None = 0,
        Buyer = 1,
        Manager = 2,
        Administrator = 4,
        ManagerAndAdmin = Manager | Administrator,
        All = Buyer | Manager | Administrator,
    }
}
