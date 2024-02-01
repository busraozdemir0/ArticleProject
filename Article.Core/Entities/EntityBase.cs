using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Core.Entities
{
    public abstract class EntityBase: IEntityBase
    {
        // Alternatif yöntem=> bu class olusturuldugu zaman asagidaki islemler gerceklestirilecektir
        //public EntityBase() { 
        //    Id=Guid.NewGuid();
        //    CreatedDate = DateTime.Now;
        //}

        // Bu kodlar ortak oldugu icin yani birden fazla tabloda icerecegi icin Core katmanında EntityBase classi olusturup burada tanimladik

        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual string? ModifiedBy { get; set; }  // ? => kimse duzenlemezse nullable yani bos gecilebilir oldugunu belirtiyoruz
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;  // aktif mi?
    }
}
