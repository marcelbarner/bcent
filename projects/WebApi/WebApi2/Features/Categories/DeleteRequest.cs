using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Features.Categories;

public record DeleteRequest([property: FromRoute] long Id);