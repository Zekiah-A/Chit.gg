using System.Collections.Generic;

namespace Chit.gg.Models;

public record Server(List<Member> Members, List<Message> Messages, object Background, object Icon);