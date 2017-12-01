namespace Cilesta.BusinessProcesses.Interfaces
{
    using DataAnnotation.Interfaces;
    using DataAnnotation.Katarina.Implimentation;

    public interface IProcessConfiguration<T> where T : IValidationModel
    {
        T Model { get; set; }
    }
}