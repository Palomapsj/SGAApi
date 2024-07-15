namespace FiapStore.Enums
{
    public enum PermissionType
    {
        Admin = 1,
        Professor = 2,
        Aluno = 3
    }

    public static class Permissions
    {
        public const string Admin = "Admin";
        public const string Professor = "Professor";
        public const string Aluno = "Aluno";
    }
}
