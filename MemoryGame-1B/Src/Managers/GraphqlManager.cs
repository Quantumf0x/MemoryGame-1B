﻿using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Common.Request;
using MemoryGame_1B.Models;

namespace MemoryGame_1B.Managers
{
    /// <summary>
    /// Handles all graphql requests
    /// </summary>
    public static class GraphqlManager
    {
        /// <summary>
        /// The graphql client
        /// </summary>
        public static readonly GraphQLClient GraphQlClient =
            new GraphQLClient("https://sleepy-falls-91203.herokuapp.com/graphql");

        /// <summary>
        /// Gets the servers
        /// </summary>
        /// <returns></returns>
        public static async Task<GetServersResponse> GetServers()
        {
            var graphQlRequest = new GraphQLRequest
            {
                Query = @"
                    query getServers {
                        getServers {
                            servers {
                                id
                                name
                                current
                            }
                            responseStatus
                        }
                    }"
            };

            var graphQlResponse = await GraphQlClient.PostAsync(graphQlRequest);
            return graphQlResponse.GetDataFieldAs<GetServersResponse>("getServers");
        }

        /// <summary>
        /// Creates a server
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task<CreateServerResponse> CreateServer(string name)
        {
            var graphQlRequest = new GraphQLRequest
            {
                Query = @"
                    mutation createServer($input: CreateServerInput) {
                        createServer(input: $input) {
                            id
                            responseStatus
                        }
                    }",
                Variables = new
                {
                    input = new
                    {
                        Name = name
                    }
                }
            };

            var graphQlResponse = await GraphQlClient.PostAsync(graphQlRequest);
            return graphQlResponse.GetDataFieldAs<CreateServerResponse>("createServer");
        }

        /// <summary>
        /// Deletes a server
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<DeleteServerResponse> DeleteServer(string id)
        {
            var graphQlRequest = new GraphQLRequest
            {
                Query = @"
                    mutation deleteServer($input: CreateServerInput) {
                        deleteServer(input: $input) {
                            responseStatus
                        }
                    }",
                Variables = new
                {
                    input = new
                    {
                        Id = id
                    }
                }
            };

            var graphQlResponse = await GraphQlClient.PostAsync(graphQlRequest);
            return graphQlResponse.GetDataFieldAs<DeleteServerResponse>("deleteServer");
        }

        /// <summary>
        /// Joins a server
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<JoinServerResponse> JoinServer(string id)
        {
            var graphQlRequest = new GraphQLRequest
            {
                Query = @"
                    query joinServer($input: JoinServerInput) {
                        joinServer(input: $input) {
                            cardData
                            responseStatus
                        }
                    }",
                Variables = new
                {
                    input = new
                    {
                        Id = id
                    }
                }
            };

            var graphQlResponse = await GraphQlClient.PostAsync(graphQlRequest);
            return graphQlResponse.GetDataFieldAs<JoinServerResponse>("joinServer");
        }

        /// <summary>
        /// Send the grid to the server
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cardData"></param>
        /// <returns></returns>
        public static async Task<CreateCardDataResponse> CreateDataGrid(string id, string cardData)
        {
            var graphQlRequest = new GraphQLRequest
            {
                Query = @"
                    mutation createDataGrid($input: CreateDataGridInput) {
                        createDataGrid(input: $input) {
                            responseStatus
                        }
                    }",
                Variables = new
                {
                    input = new
                    {
                        Id = id,
                        CardData = cardData
                    }
                }
            };

            var graphQlResponse = await GraphQlClient.PostAsync(graphQlRequest);
            return graphQlResponse.GetDataFieldAs<CreateCardDataResponse>("createDataGrid");
        }
    }
}