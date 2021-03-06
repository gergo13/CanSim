﻿using System;
using CanSimulator.Model.Node.Components;
using CanSimulator.Model.Signal;

namespace CanSimulator.Model.Node
{
    public class NodeSessionBuilder
    {
        internal NodeSessionBuilder()
        {
        }

        public CanNodeSession CreateCanNodeSession(Type microcontrollerType)
        {
            var canController = new CanController();
            IMicrocontroller microController = (IMicrocontroller)Activator.CreateInstance(microcontrollerType);
            microController.CanController = canController;
            var transceiver = new CanTransceiver(canController);
            canController.SetControllerProperties(transceiver, microController, new FrameBuilder());

            return new CanNodeSession(new CanNode(microController, transceiver));
        } 
    }
}