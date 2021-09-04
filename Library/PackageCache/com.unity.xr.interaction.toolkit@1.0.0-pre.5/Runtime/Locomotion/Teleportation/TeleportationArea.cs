namespace UnityEngine.XR.Interaction.Toolkit
{
    /// <summary>
    /// An area is a teleportation destination which teleports the user to their pointed
    /// location on a surface.
    /// </summary>
    /// <seealso cref="TeleportationAnchor"/>
    [HelpURL(XRHelpURLConstants.k_TeleportationArea)]
    public class TeleportationArea : BaseTeleportationInteractable
    {
        /// <inheritdoc />
        protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            teleportRequest.destinationPosition = raycastHit.point;
            teleportRequest.destinationRotation = transform.rotation;
            return true;
        }
    }
}
