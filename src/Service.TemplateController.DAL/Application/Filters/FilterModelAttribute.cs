namespace Service.TemplateController.DAL.Application.Filters;

[AttributeUsage(System.AttributeTargets.Property,
        AllowMultiple = true)]
public class IncludeInFilterModelAttribute : Attribute
{
    public ConditionsEnum Condition { get; set; }

    public IncludeInFilterModelAttribute(ConditionsEnum condition)
    {
        Condition = condition;
    }
}