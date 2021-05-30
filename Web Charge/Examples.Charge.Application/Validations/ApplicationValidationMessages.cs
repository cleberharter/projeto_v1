namespace Examples.Charge.Application.Validations
{
    public static class ApplicationValidationMessages
    {
        public const string PersonFoundByDescription = "A pessoa já cadastrada com o nome informado";
        public const string PersonNotFoundById = "Pessoa não encontrada com o código informado";
        public const string PersonHasItems = "Esta pessoa tem dependencias, portanto não pode ser removido";
    }
}

