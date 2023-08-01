// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Major Code Smell", "S2971:\"IEnumerable\" LINQs should be simplified", Justification = "There is already a check if there is anything in the collection.", Scope = "member", Target = "~M:Omnitudo.Core.Services.PostService.GetAll~System.Collections.Generic.List{Omnitudo.Core.Aggregates.PostAggregate}")]
[assembly: SuppressMessage("Major Code Smell", "S2971:\"IEnumerable\" LINQs should be simplified", Justification = "There is already a check if there is anything in the collection.", Scope = "member", Target = "~M:Omnitudo.Core.Services.PostService.GetPostsByCategory(System.Guid)~System.Collections.Generic.List{Omnitudo.Core.Aggregates.PostAggregate}")]
[assembly: SuppressMessage("Major Code Smell", "S2971:\"IEnumerable\" LINQs should be simplified", Justification = "There is already a check if there is anything in the collection.", Scope = "member", Target = "~M:Omnitudo.Core.Services.PostService.GetPostsByAuthor(System.Guid)~System.Collections.Generic.List{Omnitudo.Core.Aggregates.PostAggregate}")]
