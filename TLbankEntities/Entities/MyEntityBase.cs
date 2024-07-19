using System.ComponentModel.DataAnnotations;

namespace TLbankEntities.Entities;

public class MyEntityBase
{
    [Key]
    public Guid id { get; set; }
}