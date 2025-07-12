using CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.EditCarSharing;
using CarSharingApplication.DataTransferObjects;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfile.Commands.EditCarSharing
{
    public class EditCarSharingProfileModelObjectValidator : AbstractValidator<EditCarSharingProfileModelObject>
    {
        public EditCarSharingProfileModelObjectValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .MinimumLength(2).WithMessage("Name should have at least 2 characters")
                .MaximumLength(40).WithMessage("Name should have maximum 40 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter a description");

            RuleFor(c => c.PricePerDay)
                .Must(BeValidInteger).WithMessage("Price must be a valid integer")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative");

            RuleFor(c => c.NewImages).Must(HaveValidImageTypes)
                .WithMessage("Invalid image type. Allowed types are: jpg, jpeg, png, gif");

            RuleFor(c => c.PreViewImage)
                .Must(HaveValidImageTypes).WithMessage("Invalid image type. Allowed types are: jpg, jpeg, png, gif");
        }

        private bool BeValidInteger(int price)
        {
            return price % 1 == 0;
        }

        private bool HaveValidImageTypes(List<IFormFile>? images)
        {
            if (images == null || !images.Any())
            {
                return true;
            }

            var allowedImageTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };

            return images.All(image => allowedImageTypes.Contains(image.ContentType));
        }

        private bool HaveValidImageTypes(IFormFile? image)
        {
            if (image == null)
            {
                return true;
            }

            var allowedImageTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };
            return allowedImageTypes.Contains(image.ContentType);
        }
    }


}
