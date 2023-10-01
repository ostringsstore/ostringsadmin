using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ostrings.Data.Context;
using OstringsAdmin.Data.Models;
using OstringsAdmin.Enumerations;

namespace OstringsAdmin.Services.Base
{
    public class BaseRepository
    {
        protected ResponseBase<T> GetServerErrorResponse<T>(List<RepositoryError> errors, object request = null)
        {
            try
            {
                var metricParams = new Dictionary<string, string>();

                if (request != null)
                    metricParams.Add("Model", request.ToString());

                return new ResponseBase<T>()
                {
                    CustomErrors = errors,
                    IsSucces = false,
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase<T>()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
        }

        protected ResponseBase<T> GetServerErrorResponse<T>(Exception ex, object request = null)
        {
            try
            {
                var metricParams = new Dictionary<string, string>();

                if (request != null)
                    metricParams.Add("Model", request.ToString());

                return new ResponseBase<T>()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
            catch (Exception exception)
            {
                return new ResponseBase<T>()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
        }

        protected ResponseBase GetServerErrorResponse(Exception ex, object request = null)
        {
            try
            {
                var metricParams = new Dictionary<string, string>();

                if (request != null)
                    metricParams.Add("Model", request.ToString());

                return new ResponseBase()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
            catch (Exception exception)
            {
                return new ResponseBase()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
        }

        protected ResponseBase GetServerErrorResponse(List<RepositoryError> errors, object request = null)
        {
            try
            {
                var metricParams = new Dictionary<string, string>();

                if (request != null)
                    metricParams.Add("Model", request.ToString());

                return new ResponseBase()
                {
                    CustomErrors = errors,
                    IsSucces = false,
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    IsSucces = false,
                    CustomErrors = new List<RepositoryError>()
                    {
                        {
                            new RepositoryError()
                            {
                                Description = "Ha ocurrido un error en el servidor",
                                Error = ex.Message,
                                Status = StatusResponse.Unknown
                            }
                        },
                    }
                };
            }
        }
    }
}
