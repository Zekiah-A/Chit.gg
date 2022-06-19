namespace Chit.gg.Models;

public record Message(Member Sender, string Content, object Attachments);