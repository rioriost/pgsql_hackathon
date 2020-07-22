Step-by-step-Guide-01

### Task 1: Create Resource Group

1. Login to the Azure Portal, then select **Resource groups**
![Azure Portal](images/20200722073830.png 'Azure Portal')

2. Select **+ Add**
![Add resource group.](images/20200722073851.png 'Resource group')

3. On the **Create a resource group** blade, specify the following configuration options:
   a. Enter **your resource group name** for the **Resource group**.
   
   b. Select **your location** for the **Region**.
   
   c. Select **Review + create**.
![Create a resource group blade.](images/20200722073916.png 'Create a resource group')

4. Review the configurations, then select **Create**.
![Create a resource group blade.](images/20200722073920.png 'Create a resource group')

5. After the Resource Group is created, navigate to it by selecting **Go to resource group**.
![Resource groups.](images/20200722073924.png 'Resource groups')

### Task 2: Create Storage Account

1. On the **Resource group** blade, select **Create resources**.
![Resource group blade.](images/20200722073930.png 'Resource group')

2. On the **New** blade, enter **storage account** into the search box. Select Storage account from the results.
![Azure Marketplace.](images/20200722073940.png 'Azure Marketplace')
![Azure Marketplace.](images/20200722073946.png 'Azure Marketplace')

3. On the **Storage Account** blade, select **Create**.
![Storage Account blade](images/20200722073949.png 'Storage Account')

4. On the **Create storage account** blade, specify the following configuration options:

   a. Enter **your storage account name** for the **Storage account name**.
   
   b. Select **same location where resource group exists** for **Location**.
   
   c. Select **Review + create**.
![Create Storage Account blade](images/20200722074027.png 'Create Storage Account')

5. Review the configurations, then select **Create**.
![Review blade.](images/20200722074033.png 'Review')

6. After the Storage Account is created, navigate to it by selecting **Go to resource**.
![Deployment is complete.](images/20200722074106.png 'Completed deployment')

### Task 3: Create container

1. On the **Storage account** blade, select **Containers**.
![Storage account blade.](images/20200722074110.png 'Storage account')

2. On the **Containers** blade, select **+ Container**.
![Containers blade.](images/20200722074114.png 'Containers')

3. On the **New container** blade, enter **samples-workitems** for the **Name**.

![New container blade.](images/20200722074139.png 'New container')
**Note** The name you specified here will be used for the path which Blob trigger Function.

4. After the container is created, select **samples-workitmes** on the containers blade.
![containers blade.](images/20200722074145.png 'container')

### Task 4: Test uploading a file

1. On the **samples-workitems** blade, select **Upload**.
![samples-workitems blade.](images/20200722074153.png 'samples-workitems')

2. On the **Upload blob** blade, specify the following configuration options:

   a. Click **Folder icon** for to select the file, **dummy.data** on local.
   
   b. Select **Upload**.
   
   c. For your convenience in the later tasks, selecting **Overwrite if files already exist** is reccommended.
![Upload blob blade.](images/20200722074204.png 'Upload blob')

3. After the file is uploaded, you can see the name of file on the **samples-workitems** blade.
![Uploaded file.](images/20200722074213.png 'Uploaded')


![A diagram showing the range of hackathon.](images/20200722074246.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074258.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074304.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074326.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074333.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074458.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074510.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074515.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074522.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722074534.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075100.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075105.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075116.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075125.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075158.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075208.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075212.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075219.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075333.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075629.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075717.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075729.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075803.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075814.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075823.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075909.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075918.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075924.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075941.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722075942.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080004.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080015.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080020.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080118.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080125.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080247.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080259.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080309.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080328.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080438.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080513.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080705.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722080749.png 'Solution Architecture')
![A diagram showing the range of hackathon.](images/20200722081531.png 'Solution Architecture')
