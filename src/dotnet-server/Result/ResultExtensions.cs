﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Features.Results;
public static class ResultExtensions
{
    public static T Success<T>(this T result, string message = null) where T : Result
    {
        result.Status = ResultStatus.Ok;
        if (message != null)
        {
            result.SuccessMessage = message;
        }
        return result;
    }

    public static T Error<T>(this T result, string message = null) where T : Result
    {
        result.Status = ResultStatus.Error;
        if (message != null)
        {
            result.ErrorMessage = message;
        }
        return result;
    }

    public static T Error<T>(this T result, IEnumerable<string> errors) where T : Result
    {
        result.Status = ResultStatus.Error;
        foreach (var error in errors)
        {
            result.Errors.Add(error);
        }
        return result;
    }

    public static T Invalid<T>(this T result, string message = null) where T : Result
    {
        result.Status = ResultStatus.Invalid;
        if (message != null)
        {
            result.ErrorMessage = message;
        }
        return result;
    }
    public static T Invalid<T>(this T result, ModelStateDictionary modelState, string message = null) where T : Result
    {
        result.Status = ResultStatus.Invalid;
        result.ValidationErrors = modelState.ToDictionary();
        if (message != null)
        {
            result.ErrorMessage = message;
        }
        return result;
    }

    public static T Invalid<T>(this T result, IEnumerable<string> errors, string message = null) where T : Result
    {
        result.Status = ResultStatus.Invalid;
        foreach (var error in errors)
        {
            result.ValidationErrors.Add("", error);
        }
        if (message != null)
        {
            result.ErrorMessage = message;
        }
        return result;
    }

    public static T Invalid<T>(this T result, string field, string error, string message = null) where T : Result
    {
        result.Status = ResultStatus.Invalid;
        result.ValidationErrors.Add(field, error);
        if (message != null)
        {
            result.ErrorMessage = message;
        }
        return result;
    }

}
