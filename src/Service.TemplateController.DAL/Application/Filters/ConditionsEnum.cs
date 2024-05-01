namespace Service.TemplateController.DAL.Application.Filters;


public enum ConditionsEnum
{
    /// <summary>
    /// "&lt;" condition
    /// </summary>
    Less,
    /// <summary>
    /// "&lt;=" condition
    /// </summary>
    LessOrEquals,
    /// <summary>
    /// "=" condition
    /// </summary>
    Equals,
    /// <summary>
    /// "&gt;=" condition
    /// </summary>
    GreaterOrEquals,
    /// <summary>
    /// "&gt;" condition
    /// </summary>
    Greater,
    HasValue,
    NoValue,
}
