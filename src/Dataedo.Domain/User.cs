namespace Dataedo.Domain;

public class User
{
    public Guid Id { get; private set; }
    public bool IsActive { get; private set; }
    public string Name { get; private set; }

    internal User()
    {
    }

    public static User Create(string name)
    {
        var newUser = new User();
        newUser.Id = Guid.NewGuid();
        newUser.SetActivation(true);
        newUser.SetName(name);

        return newUser;
    }

    public void SetActivation(bool isUserActive)
    {
        IsActive = isUserActive;
    }

    public void SetName(string newName)
    {
        if (String.IsNullOrEmpty(newName) || String.IsNullOrWhiteSpace(newName))
            throw new ArgumentNullException(nameof(newName), "Name can not be empty!");

        Name = newName;
    }
}