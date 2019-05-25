using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data {
    public abstract class AbstractEntity : Entity {
        [StringLength(36)]
        public string Id { get; set; }
    }
}
