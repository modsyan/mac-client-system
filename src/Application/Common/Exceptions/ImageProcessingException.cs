namespace MacClientSystem.Application.Common.Exceptions;


public class ImageProcessingException(string message, Exception innerException) : Exception(message, innerException);
