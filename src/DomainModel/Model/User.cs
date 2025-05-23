﻿
namespace DomainModel.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

	public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public byte[]? Icon { get; set; }
    public bool? UseTwoFactorAuthentication { get; set; }

	public virtual ICollection<Canvas> Canvas { get; set; }
    public virtual TotpRestoreAccess TotpRestoreAccess { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<InteractiveCanvas> InteractiveCanvas { get; set; }
    public virtual ICollection<VersionProject> VersionsProjects { get; set; }
    public virtual ICollection<LikeOfCanvas> LikeOfCanvas { get; set; }
    public virtual ICollection<LikeOfVersionProject> LikeOfVersionProject{ get; set; }
}
