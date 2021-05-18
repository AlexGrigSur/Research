// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/customUser.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Research_GRPC {
  public static partial class UsersHandler
  {
    static readonly string __ServiceName = "UsersHandler";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Research_GRPC.UserNumber> __Marshaller_UserNumber = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Research_GRPC.UserNumber.Parser));
    static readonly grpc::Marshaller<global::Research_GRPC.UserModel> __Marshaller_UserModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Research_GRPC.UserModel.Parser));
    static readonly grpc::Marshaller<global::Research_GRPC.Empty> __Marshaller_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Research_GRPC.Empty.Parser));
    static readonly grpc::Marshaller<global::Research_GRPC.UserModelWithKey> __Marshaller_UserModelWithKey = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Research_GRPC.UserModelWithKey.Parser));
    static readonly grpc::Marshaller<global::Research_GRPC.UserQuery> __Marshaller_UserQuery = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Research_GRPC.UserQuery.Parser));

    static readonly grpc::Method<global::Research_GRPC.UserNumber, global::Research_GRPC.UserModel> __Method_GetSingleUser = new grpc::Method<global::Research_GRPC.UserNumber, global::Research_GRPC.UserModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSingleUser",
        __Marshaller_UserNumber,
        __Marshaller_UserModel);

    static readonly grpc::Method<global::Research_GRPC.Empty, global::Research_GRPC.UserModelWithKey> __Method_GetAllUsersStream = new grpc::Method<global::Research_GRPC.Empty, global::Research_GRPC.UserModelWithKey>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAllUsersStream",
        __Marshaller_Empty,
        __Marshaller_UserModelWithKey);

    static readonly grpc::Method<global::Research_GRPC.Empty, global::Research_GRPC.UserQuery> __Method_GetAllUsersCollection = new grpc::Method<global::Research_GRPC.Empty, global::Research_GRPC.UserQuery>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllUsersCollection",
        __Marshaller_Empty,
        __Marshaller_UserQuery);

    static readonly grpc::Method<global::Research_GRPC.UserModelWithKey, global::Research_GRPC.Empty> __Method_AddUser = new grpc::Method<global::Research_GRPC.UserModelWithKey, global::Research_GRPC.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddUser",
        __Marshaller_UserModelWithKey,
        __Marshaller_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Research_GRPC.CustomUserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UsersHandler</summary>
    [grpc::BindServiceMethod(typeof(UsersHandler), "BindService")]
    public abstract partial class UsersHandlerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Research_GRPC.UserModel> GetSingleUser(global::Research_GRPC.UserNumber request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task GetAllUsersStream(global::Research_GRPC.Empty request, grpc::IServerStreamWriter<global::Research_GRPC.UserModelWithKey> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Research_GRPC.UserQuery> GetAllUsersCollection(global::Research_GRPC.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Research_GRPC.Empty> AddUser(global::Research_GRPC.UserModelWithKey request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(UsersHandlerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSingleUser, serviceImpl.GetSingleUser)
          .AddMethod(__Method_GetAllUsersStream, serviceImpl.GetAllUsersStream)
          .AddMethod(__Method_GetAllUsersCollection, serviceImpl.GetAllUsersCollection)
          .AddMethod(__Method_AddUser, serviceImpl.AddUser).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UsersHandlerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSingleUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Research_GRPC.UserNumber, global::Research_GRPC.UserModel>(serviceImpl.GetSingleUser));
      serviceBinder.AddMethod(__Method_GetAllUsersStream, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Research_GRPC.Empty, global::Research_GRPC.UserModelWithKey>(serviceImpl.GetAllUsersStream));
      serviceBinder.AddMethod(__Method_GetAllUsersCollection, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Research_GRPC.Empty, global::Research_GRPC.UserQuery>(serviceImpl.GetAllUsersCollection));
      serviceBinder.AddMethod(__Method_AddUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Research_GRPC.UserModelWithKey, global::Research_GRPC.Empty>(serviceImpl.AddUser));
    }

  }
}
#endregion
