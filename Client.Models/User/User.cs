namespace Client.Models.User
{
  using System;

  /// <summary>
  /// Пользователь
  /// </summary>
  public class User
  {
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; set; }
        
    /// <summary>
    /// Дата регистрации пользователя
    /// </summary>
    public string RegisteredAt { get; set; }
  }
}