﻿using FluentValidation.TestHelper;
using Xunit;

namespace CarWorkshop.Application.CarWorkshopService.Commands.Tests
{
    public class CreateCarWorkshopServiceValidatorTests
    {
        [Fact]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            // Arrange
            var validator = new CreateCarWorkshopServiceValidator();
            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "100PLN",
                Description = "Description",
                CarWorkshopEncodedName = "workshop1"
            };

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
        
        [Fact]
        public void Validate_WithInvalidCommand_ShouldHaveValidationErrors()
        {
            // Arrange
            var validator = new CreateCarWorkshopServiceValidator();
            var command = new CreateCarWorkshopServiceCommand()
            {
                Cost = "",
                Description = "",
                CarWorkshopEncodedName = null
            };

            // Act
            var result = validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Cost);
            result.ShouldHaveValidationErrorFor(c => c.Description);
            result.ShouldHaveValidationErrorFor(c => c.CarWorkshopEncodedName);
        }
    }
}