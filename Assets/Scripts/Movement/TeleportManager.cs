using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    // Start is called before the first frame update
    private InputAction _thumbstick;
    private bool _IsActive;
    private RaycastHit hit;
    private XrInput input;
    void Start()
    {
        input = new XrInput(actionAsset);
        rayInteractor.enabled = false;
        var activate = input.GetInput(XrEnum.LeftTeleportModeActivate);
        activate.Enable();
        activate.performed += OnTeleportActivate;

        var cancel = input.GetInput(XrEnum.LeftTeleportModeCancel);
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _thumbstick = input.GetInput(XrEnum.LeftMove);
        _thumbstick.Enable();

    }

    private void OnTeleportCancel(InputAction.CallbackContext obj)
    {
        setTeleportState(false);
    }

    private void OnTeleportActivate(InputAction.CallbackContext obj)
    {
        setTeleportState(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsActive || _thumbstick.triggered)
            return;
        
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            setTeleportState(false);
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point
        };

        provider.QueueTeleportRequest(request);
    }

    private void setTeleportState(bool state)
    {
        rayInteractor.enabled = state;
        _IsActive = state;
    }

}
