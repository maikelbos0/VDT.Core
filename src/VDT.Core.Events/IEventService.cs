﻿using System;
using System.Threading.Tasks;

namespace VDT.Core.Events {
    /// <summary>
    /// Specifies the contract for event services
    /// </summary>
    public interface IEventService {
        /// <summary>
        /// Register an event handler
        /// </summary>
        /// <typeparam name="TEvent">Type of the event to handle</typeparam>
        /// <param name="handler">Handler that handles the event</param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        /// <remarks>Multiple event handlers can be registered for the same event type</remarks>
        IEventService RegisterHandler<TEvent>(IEventHandler<TEvent> handler);
        
        /// <summary>
        /// Register an event handler
        /// </summary>
        /// <typeparam name="TEvent">Type of the event to handle</typeparam>
        /// <param name="handler">Handler that handles the event</param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        /// <remarks>Multiple event handlers can be registered for the same event type</remarks>
        IEventService RegisterHandler<TEvent>(IAsyncEventHandler<TEvent> handler);

        /// <summary>
        /// Register an action as an event handler
        /// </summary>
        /// <typeparam name="TEvent">Type of the event to handle</typeparam>
        /// <param name="action">Handler action that handles the event</param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        /// <remarks>Multiple event handlers can be registered for the same event type</remarks>
        IEventService RegisterHandler<TEvent>(Action<TEvent> action);

        /// <summary>
        /// Register an action as an event handler
        /// </summary>
        /// <typeparam name="TEvent">Type of the event to handle</typeparam>
        /// <param name="action">Handler action that handles the event</param>
        /// <returns>A reference to this instance after the operation has completed</returns>
        /// <remarks>Multiple event handlers can be registered for the same event type</remarks>
        IEventService RegisterHandler<TEvent>(Func<TEvent, Task> action);

        /// <summary>
        /// Dispatch an event by its object type and trigger all registered event handlers for that event
        /// </summary>
        /// <param name="event">Event to handle</param>
        /// <returns>A <see cref="Task"/> that represents the operation of handling the event</returns>
        /// <remarks>Event type is automatically resolved from the event object</remarks>
        Task DispatchObject(object @event);

        /// <summary>
        /// Dispatch an event and trigger all registered event handlers for that event
        /// </summary>
        /// <typeparam name="TEvent">Type of the event to handle</typeparam>
        /// <param name="event">Event to handle</param>
        /// <returns>A <see cref="Task"/> that represents the operation of handling the event</returns>
        Task DispatchEvent<TEvent>(TEvent @event);
    }
}
